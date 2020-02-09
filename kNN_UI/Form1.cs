
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wine_API.Models;
using kNN;

namespace kNN_UI
{
   
    public partial class Form1 : Form
    {
        public APIHelper winequalityRedService = new APIHelper("http://localhost:60854", "api/winequalityRed");
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeComponent();

            List<winequalityRed> PodaciZaTreniranje = new List<winequalityRed>();
            List<winequalityRed> TreningPodaci = new List<winequalityRed>();

            HttpResponseMessage response = winequalityRedService.GetResponseA("GetPodaciZaTreniranje");
            if (response.IsSuccessStatusCode)
            {
                PodaciZaTreniranje = response.Content.ReadAsAsync<List<winequalityRed>>().Result; ;
            }

           

            HttpResponseMessage response2 = winequalityRedService.GetResponseA("GetTreniraniPodaci");
            if (response2.IsSuccessStatusCode)
            {
                TreningPodaci = response2.Content.ReadAsAsync<List<winequalityRed>>().Result; ;
            }

            Algorithm_ alg = new Algorithm_(3, TreningPodaci, PodaciZaTreniranje);
            alg.runkNN();

        }
    }
}
