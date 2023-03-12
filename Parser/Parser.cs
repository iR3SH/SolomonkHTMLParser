using Data;
using Data.Classes;
using Data.IRepository;
using PuppeteerSharp;
using System.Linq.Expressions;

namespace Parser
{
    public partial class Parser : Form
    {
        readonly IMonstersRepository _repoMonsters;
        List<Monsters>? monsters;
        readonly string NewLine = Environment.NewLine;
        readonly string NewLineClean = Environment.NewLine + Environment.NewLine;
        IBrowser? Browser;
        IPage? Page;
        int toDo = 0, done = 0;
        public Parser(IMonstersRepository repoMonsters)
        {
            _repoMonsters = repoMonsters;
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            NumRequestLabel.Visible = false;
            loggerText.Text += "Chargement des Monstres...";
            StateLabel.Text = "En cours";
            StateLabel.ForeColor = Color.Orange;

            monsters = await _repoMonsters.GetAll();

            loggerText.Text += NewLine + monsters.Count + " Monstres ont été chargées";
            StateLabel.Text = "Prêt";
            StateLabel.ForeColor = Color.Green;
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            try {
            loggerText.Text += NewLineClean + "Début du ParseMonster...";
            StateLabel.Text = "En cours";
            StateLabel.ForeColor = Color.Orange;

                if (monsters != null)
                {
                    toDo = monsters.Count;
                    done = 0;
                    NumRequestLabel.Text = done + " / " + toDo;
                    NumRequestLabel.Visible = true;
                    LaunchOptions Options = new()
                    {
                        Headless = true,
                        // Votre Path vers l'executable de Google Chrome
                        ExecutablePath = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
                    };
                    Browser = await Puppeteer.LaunchAsync(Options, null);
                    Page = await Browser.NewPageAsync();
                    foreach (Monsters monster in monsters)
                    {
                        loggerText.Text += NewLineClean + "Parse du Monstre : " + monster.Name;

                        Functions.ParseMonstersData(await Functions.GetSolomonkMonsterPage(Page, monster.Id), monster);
                        loggerText.Text += NewLine + "Parse Terminé";
                        loggerText.Text += NewLine + "Mise à jour BDD";
                        await _repoMonsters.Update(monster);

                        loggerText.Text += NewLine + "Mise à jour Terminée";
                        done++;
                        NumRequestLabel.Text = done + " / " + toDo;
                        loggerText.SelectionStart = loggerText.Text.Length;
                        loggerText.ScrollToCaret();
                    }
                    await DisposeBrowser();
                    StateLabel.Text = "Prêt";
                    StateLabel.ForeColor = Color.Green;
                    loggerText.Text += NewLineClean + "Parsing Terminée !";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                await DisposeBrowser();
                StateLabel.Text = "Erreur Critique";
                StateLabel.ForeColor = Color.Red;
            }
        }
        private async Task DisposeBrowser()
        {
            if (Page != null)
            {
                await Page.DisposeAsync();
                await Page.CloseAsync();
                Page = null;
            }
            if (Browser != null)
            {
                await Browser.DisposeAsync();
                await Browser.CloseAsync();
                Browser = null;
            }
        }

        private async void Parser_FormClosed(object sender, FormClosedEventArgs e)
        {
            await DisposeBrowser();
        }
    }
}