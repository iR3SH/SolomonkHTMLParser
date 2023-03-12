using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using Data.Classes;
using PuppeteerSharp;

namespace Data
{
    public class Functions
    {
        public static void ParseMonstersData(string html, Monsters monster)
        {
            if (!string.IsNullOrEmpty(html) && monster != null)
            {
                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(html);
                var document = htmlDocument.DocumentNode;

                List<HtmlNode> node = document.QuerySelectorAll(".icon-entity").ToList();
                if (node != null)
                {
                    HtmlNode? nodeVita = node.FirstOrDefault(c => c.OuterHtml.Contains("icon-vita"));
                    HtmlNode? nodeIni = node.FirstOrDefault(c => c.OuterHtml.Contains("icon-init"));
                    if (nodeVita != null && nodeIni != null)
                    {
                        string[] vita = nodeVita.Attributes.Where(c => c.Name.Contains("data-rank")).Select(c => c.Value).ToArray();
                        string[] init = nodeIni.Attributes.Where(c => c.Name.Contains("data-rank")).Select(c => c.Value).ToArray();
                        if (vita.Length > 0 && init.Length > 0)
                        {
                            string newVita = "", newInit = "";
                            for (int i = 0; i < vita.Length; i++)
                            {
                                if (i != vita.Length - 1)
                                {
                                    newVita += vita[i] + "|";
                                }
                                else
                                {
                                    newVita += vita[i];
                                }
                            }
                            for (int i = 0; i < init.Length; i++)
                            {
                                if (i != init.Length - 1)
                                {
                                    newInit += init[i] + "|";
                                }
                                else
                                {
                                    newInit += init[i];
                                }
                            }
                            monster.Pdvs = newVita;
                            monster.Inits = newInit;
                        }
                    }
                }
            }
        }
        public static async Task<string> GetSolomonkMonsterPage(IPage page, int MonsterId)
        {
            string fullUrl = "https://solomonk.fr/fr/monstre/" + MonsterId;
            await page.GoToAsync(fullUrl);

            return await page.GetContentAsync();
        }
    }
}
