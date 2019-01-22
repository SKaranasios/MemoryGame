using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBoxs[0] = pictureBox1;
            pictureBoxs[1] = pictureBox2;
            pictureBoxs[2] = pictureBox3;
            pictureBoxs[3] = pictureBox4;
            pictureBoxs[4] = pictureBox5;
            pictureBoxs[5] = pictureBox6;
            pictureBoxs[6] = pictureBox7;
            pictureBoxs[7] = pictureBox8;
            pictureBoxs[8] = pictureBox9;
            pictureBoxs[9] = pictureBox10;
            pictureBoxs[10] = pictureBox11;
            pictureBoxs[11] = pictureBox12;
            pictureBoxs[12] = pictureBox13;
            pictureBoxs[13] = pictureBox14;
            pictureBoxs[14] = pictureBox15;
            pictureBoxs[15] = pictureBox16;
        }

        PictureBox[] pictureBoxs = new PictureBox[16];
        Random rnd = new Random();
        PictureBox prev;
        bool same=false;//μεταβλητη για ελεγχο
        int remain = 8;//υπολοιπομενα ζευγαρια


        void SetDefaultPicture()
        {
            for (int i = 0; i < 16; i++)
            {
                //Σε ολες τις εικονες του πινακα/φορμας  θετει default image
                pictureBoxs[i].Image = Properties.Resources._0;

            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            SetGame();
        }

        void TagtoPicture(PictureBox picture)
        {
            switch (Convert.ToInt32(picture.Tag))
            {
                default:
                    picture.Image = Properties.Resources._0;
                    break;
                case 1:
                    picture.Image = Properties.Resources._1;
                    break;
                case 2:
                    picture.Image = Properties.Resources._2;
                    break;
                case 3:
                    picture.Image = Properties.Resources._3;
                    break;
                case 4:
                    picture.Image = Properties.Resources._4;
                    break;
                case 5:
                    picture.Image = Properties.Resources._5;
                    break;
                case 6:
                    picture.Image = Properties.Resources._6;
                    break;
                case 7:
                    picture.Image = Properties.Resources._7;
                    break;
                case 8:
                    picture.Image = Properties.Resources._8;
                    break;
                
            }
            //μετατρεπει το tag σε image

        }
        void TagRandom()
        {
            int[] tags = new int[] {1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8 };
            int index = 0;
            int[] MyRandomArray = tags.OrderBy(x => rnd.Next()).ToArray();
            for (int i = 0; i < 16; i++)
            {
                pictureBoxs[i].Tag = MyRandomArray[index].ToString();
                index++;
            }
        }
        //δημιουργει ενα array με τα tags το αλλαζει σε τυχαιες θεσεις και τα θετει στα pictureboxes
        void Compare(PictureBox previous, PictureBox current)
        {
            if (previous.Tag.ToString() == current.Tag.ToString())
            {
                previous.Visible = true;
                current.Visible = true;
                previous.Enabled = false;
                current.Enabled = false;
                remain--;
                if (remain == 0)
                {
                    MessageBox.Show("End of Game");
                }
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                previous.Image = Image.FromFile("0.png");
                current.Image = Image.FromFile("0.png");
            }
        }
        /*συγκρινει τα strings της πρωτης που ανοιχτηκε με την δευτερη
         * Kαι αν ειανι ιδια τα αφηνει ανοιχτα και τα απενεργοποιει για να μην μπορουν να ξαναπατηθουν
         */

        void SetGame()
        {
            SetDefaultPicture();
            TagRandom();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox box = sender as PictureBox;
            box.Image = Image.FromFile(box.Tag.ToString() + ".png");
            TagtoPicture(box);
            if (same==false)
            {
                prev = box;
                same = true;
            }
            else if (prev != box)
            {
                Application.DoEvents();
                Compare(prev, box);
                same = false;
            }
        }
        /*την πρωτη φορα που πατιεται η εικονα δεν κανει τον ελεγχο συκρισης
         * Θετει το picturebox prev με αυτη την picturebox που επιλεχθηκε
         * και την bool μεταβλητη true για να βγει απο το  if
         * ενω στο δευτετο κλικ  γινεται συγκριση των δυο εφοσον δεν πατιεται το ιδιο picturebox
         */
    }
}
