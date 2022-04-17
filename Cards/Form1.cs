using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOLayer;

namespace Cards
{
    public partial class Form1 : Form
    {
        private Deck aDeck;
        private Hand hand1;
        private Hand hand2;
        private int i;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SetUp()
        {

            try
            {
                aDeck = new Deck();
                aDeck.Shuffle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            Panel1.Controls.Clear();
            Panel2.Controls.Clear();
            Panel1Draw1.Controls.Clear();
            Panel1Draw2.Controls.Clear();
            Panel1Draw3.Controls.Clear();
            Panel2Draw1.Controls.Clear();
            Panel2Draw2.Controls.Clear();
            Panel2Draw3.Controls.Clear();

            bntDraw1.Enabled = false;
            btnDraw2.Enabled = false;
            bntDone.Enabled = false;
            btnDeal.Enabled = true;
        }

        private void Draw(object sender, EventArgs e)
        {

            // Hand 1
            hand1 = aDeck.DealHand(2);
            ShowCard(Panel1, hand1);

            // Hand 2
            hand2 = aDeck.DealHand(2);
            ShowCard(Panel2, hand2);


        }

        private void ShowCard(Panel thePannel, Hand theHand)
        {
            Card aCard;
            PictureBox aPic;
            for (int i = 0; i < theHand.Count; i++)
            {
                aCard = theHand[i];
                string imgPath = $@"images\{aCard.FaceValue.ToString()}{aCard.Suit.ToString()}.jpg";

                aPic = new PictureBox()
                {
                    Image = Image.FromFile(imgPath),
                    Text = aCard.FaceValue.ToString(),
                    Width = 71,
                    Height = 100,
                    Left = 75 * i
                };

                thePannel.Controls.Add(aPic);
                bntDraw1.Enabled = true;
                bntDone.Enabled = true;
                btnDeal.Enabled = false;

            }
        }

        private void btnRedeal_Click(object sender, EventArgs e)
        {
            SetUp();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            SetUp();
        }

        private void bntDraw1_Click(object sender, EventArgs e)
        {
            int a = i++;

            if (a == 1)
            {
                hand1 = aDeck.DealHand(1);
                ShowCard(Panel1Draw1, hand1);
            }

            else if (a == 2)
            {
                hand1 = aDeck.DealHand(1);
                ShowCard(Panel1Draw2, hand1);
            }

            else if (a == 3)
            {
                hand1 = aDeck.DealHand(1);
                ShowCard(Panel1Draw3, hand1);

                bntDraw1.Enabled = false;
            }


        }

        private void bntDone_Click(object sender, EventArgs e)
        {
            bntDraw1.Enabled = false;
            btnDraw2.Enabled = true;

            i = 0;
        }

        private void btnDraw2_Click(object sender, EventArgs e)
        {
            int v = i++;

            if (v == 1)
            {
                hand2 = aDeck.DealHand(1);
                ShowCard(Panel2Draw1, hand2);
            }

            else if (v == 2)
            {
                hand2 = aDeck.DealHand(1);
                ShowCard(Panel2Draw2, hand2);
            }

            else if (v == 3)
            {
                hand2 = aDeck.DealHand(1);
                ShowCard(Panel2Draw3, hand2);

                btnDraw2.Enabled = false;
            }
        }
    }
}
