using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mandelbrot
{

    partial class MandelForm
    {
        // membervariabelen
        Bitmap tekening;
        double schaal = 0.01;
        double schaalfactor = 1;
        double xklik = 0;
        double yklik = 0;
        double xmidden = 0;
        double ymidden = 0;
        double mandelgetalmax = 100;
        Color kleur;
        Color kleur1 = Color.Black;
        Color kleur2 = Color.White;
        Color kleur3 = Color.White;
        Color kleur4 = Color.White;
        Color kleur5 = Color.White;
        Color kleur6 = Color.Black;
        Color kleur7 = Color.Black;
        Color kleur8 = Color.Black;


        // mandelgetal berekenen
        public double BerekenMandel(double xmandel, double ymandel)
        {
            double a, b;
            double mandelgetal = 0; 
            double mandelroot = 0; 
            a = xmandel;
            b = ymandel;

            while ((mandelgetal <= mandelgetalmax) && (mandelroot <= 2))
            {
                double temp_a = a;
                a = (a * a - b * b + xmandel);
                b = (2 * temp_a * b + ymandel);
                mandelroot = Math.Sqrt(a * a + b * b);
                mandelgetal++;

            }
            return mandelgetal;
        }


        // pixels converteren naar mandelassenstelsel en bitmap tekenen
        public void Tekenmandel(object obj, PaintEventArgs pea)
        {
            // koppeling van bitmap aan picturebox
            tekening = new Bitmap(picturebox.Width, picturebox.Height);

            for (int x = 0; x < picturebox.Width; x++)
            {
                for (int y = 0; y < picturebox.Height; y++)
                {
                    double xmandel = xmidden + schaal * (x - picturebox.Width/2);
                    double ymandel = ymidden + schaal * (picturebox.Height/2 - y);

                    if ((int)(BerekenMandel(xmandel, ymandel)) % 2 == 1)
                        kleur = kleur1;
                    else if ((int)(BerekenMandel(xmandel, ymandel)) % 3 == 1)
                        kleur = kleur3;
                    else if ((int)(BerekenMandel(xmandel, ymandel)) % 4 == 0)
                        kleur = kleur4;
                    else if ((int)(BerekenMandel(xmandel, ymandel)) % 5 == 1)
                        kleur = kleur5;
                    else if ((int)(BerekenMandel(xmandel, ymandel)) % 3 == 0)
                        kleur = kleur6;
                    else if ((int)(BerekenMandel(xmandel, ymandel)) % 5 == 0)
                        kleur = kleur7;
                    else if ((int)(BerekenMandel(xmandel, ymandel)) % 7 == 0)
                        kleur = kleur8;
                    else
                        kleur = kleur2;

                    tekening.SetPixel(x, y, kleur);
                }
            }

            picturebox.Image = tekening;
        }


        // methode om te vergroten waar er geklikt wordt
        public void Klikzoom(object sender, EventArgs mea)
        {
            xklik = (double)((System.Windows.Forms.MouseEventArgs)mea).X;
            yklik = (double)((System.Windows.Forms.MouseEventArgs)mea).Y;

             xmidden = xmidden + schaal * (xklik - picturebox.Width/2);
             ymidden = ymidden + schaal * (picturebox.Height/2 - yklik);

            try
            {
                schaalfactor = double.Parse(Schaalfactor.Text);

            }
            catch (Exception)
            {
            }

            schaal = schaalfactor * schaal;

            MiddenX.Text = xmidden.ToString();
            MiddenY.Text = ymidden.ToString();
            Schaal.Text = schaal.ToString();
            Max.Text = mandelgetalmax.ToString();
            Schaalfactor.Text = schaalfactor.ToString();

            Invalidate();
        }


        // methode voor het klik event van de buttons OK en Reset
        public void Knopklik_Click(object sender, System.EventArgs e)
        {
            if (sender == this.OK)
            {
                try
                {
                    // converteren van tekst uit tekstboxen naar doubles en deze toekennen aan de variabelen
                    schaal = double.Parse(Schaal.Text);
                    ymidden = double.Parse(MiddenY.Text);
                    mandelgetalmax = double.Parse(Max.Text);
                    xmidden = double.Parse(MiddenX.Text);
                    schaalfactor = double.Parse(Schaalfactor.Text);
                }
                catch (Exception)
                {
                }
                schaal = schaalfactor * schaal;

            }

            // deze zet de gegevens (excl. kleur) en schaal terug naar de beginstand
            if (sender == this.Reset)
            {
                schaal = 0.01;
                xmidden = 0;
                ymidden = 0;
                mandelgetalmax = 100;
                schaalfactor = 0.5;
            }

            // converteren van de doubles van de variabelen naar strings en deze toekennen aan de tekstboxen
            MiddenX.Text = xmidden.ToString();
            MiddenY.Text = ymidden.ToString();
            Schaal.Text = schaal.ToString();
            Max.Text = mandelgetalmax.ToString();
            Schaalfactor.Text = schaalfactor.ToString();

            Invalidate();
        }


        // methode voor het klik event van de tekst in de combobox
            public void Keuzelijst_SelectedIndexChanged(object sender, EventArgs evt)
        {
            string gekozenwaarde = ((ComboBox)sender).SelectedText;
            switch (gekozenwaarde)
            {
                case "basis":

                    schaal = 0.01;
                    xmidden = 0;
                    ymidden = 0;
                    mandelgetalmax = 100;
                    schaalfactor = 0.5;
                    kleur1 = Color.Black;
                    kleur2 = Color.White;
                    kleur3 = Color.White;
                    kleur4 = Color.White;
                    kleur5 = Color.White;
                    kleur6 = Color.Black;
                    kleur7 = Color.Black;
                    kleur8 = Color.Black;
                    MiddenX.Text = xmidden.ToString();
                    MiddenY.Text = ymidden.ToString();
                    Schaal.Text = schaal.ToString();
                    Max.Text = mandelgetalmax.ToString();
                    Schaalfactor.Text = schaalfactor.ToString();

                    break;

                case "neon":

                    xmidden = -1.1532226562;
                    ymidden = 0.3066015625;
                    schaal = 0.000009765625;
                    mandelgetalmax = 300;
                    schaalfactor = 0.5;

                    kleur1 = Color.Black;
                    kleur2 = Color.Aqua;
                    kleur3 = Color.BlueViolet;
                    kleur4 = Color.HotPink;
                    kleur5 = Color.Aquamarine;
                    kleur6 = Color.Lime;
                    kleur7 = Color.Cyan;

                    MiddenX.Text = xmidden.ToString();
                    MiddenY.Text = ymidden.ToString();
                    Schaal.Text = schaal.ToString();
                    Max.Text = mandelgetalmax.ToString();
                    Schaalfactor.Text = schaalfactor.ToString();

                    break;

                case "tunnel":

                    xmidden = 0.43820090888;
                    ymidden = -0.2505415793;
                    schaal = 0.0000000000745;
                    mandelgetalmax = 100;
                    schaalfactor = 0.5;


                    kleur1 = Color.Navy;
                    kleur2 = Color.LimeGreen;
                    kleur3 = Color.LimeGreen;
                    kleur4 = Color.Yellow;
                    kleur5 = Color.Red;
                    kleur6 = Color.Red;
                    kleur7 = Color.HotPink;
                    kleur8 = Color.Yellow;

                    MiddenX.Text = xmidden.ToString();
                    MiddenY.Text = ymidden.ToString();
                    Schaal.Text = schaal.ToString();
                    Max.Text = mandelgetalmax.ToString();
                    Schaalfactor.Text = schaalfactor.ToString();

                    break;

                case "kristal":
                    xmidden = -0.5470214843;
                    ymidden = 0.62149902343;
                    schaal = 0.0000048828125;
                    mandelgetalmax = 100;
                        schaalfactor = 0.5;

                    kleur1 = Color.Black;
                    kleur2 = Color.LightCyan;
                    kleur3 = Color.LightCyan;
                    kleur4 = Color.PowderBlue;
                    kleur5 = Color.PowderBlue;
                    kleur6 = Color.AliceBlue;
                    kleur7 = Color.White;
                    kleur8 = Color.PowderBlue;

                    MiddenX.Text = xmidden.ToString();
                    MiddenY.Text = ymidden.ToString();
                    Schaal.Text = schaal.ToString();
                    Max.Text = mandelgetalmax.ToString();
                    Schaalfactor.Text = schaalfactor.ToString();

                    break;

                case "kerstkrans":

                    xmidden = -0.5298514404;
                    ymidden = 0.61805523681;
                    schaal = 0.000004150390625;
                    mandelgetalmax = 100;
                    schaalfactor = 0.5;

                    kleur1 = Color.Black;
                    kleur2 = Color.Green;
                    kleur3 = Color.Green;
                    kleur4 = Color.Red;
                    kleur5 = Color.Green;
                    kleur6 = Color.Green;
                    kleur7 = Color.Red;
                    kleur8 = Color.Green;

                    MiddenX.Text = xmidden.ToString();
                    MiddenY.Text = ymidden.ToString();
                    Schaal.Text = schaal.ToString();
                    Max.Text = mandelgetalmax.ToString();
                    Schaalfactor.Text = schaalfactor.ToString();

                    break;
            }
            Invalidate();
        }

    }
   
}
