using System;
using System.Windows.Forms;
using System.Drawing;

namespace Mandelbrot
{
    

   public partial class MandelForm : Form
{
        // membervariabelen
        PictureBox picturebox;
        ComboBox Keuzelijst;
        Button OK;
        Button Reset;
        TextBox MiddenX;
        TextBox MiddenY;
        TextBox Schaal;
        TextBox Schaalfactor;
        TextBox Max;

    public MandelForm()
    {
            this.ClientSize = new Size(460, 535);
            this.BackColor = Color.WhiteSmoke;
            this.Text = "Mandelbrot";
            this.Paint += TekenScherm;
            
            // picturebox
            picturebox = new PictureBox();
            picturebox.Paint += Tekenmandel;
            picturebox.Location = new Point(30, 110);
            picturebox.Size = new Size(400, 400);
            picturebox.BackColor = Color.Black;
            Controls.Add(picturebox);
            picturebox.Click += Klikzoom;

            // combobox
            Keuzelijst = new ComboBox();
            Keuzelijst.FormattingEnabled = true;
            Keuzelijst.Items.AddRange(new object[] { "basis", "neon", "tunnel", "kristal", "kerstkrans" });
            Keuzelijst.Location = new Point(95, 75);
            Keuzelijst.Name = "Keuzelijst";
            Keuzelijst.Text = "basis";
            Keuzelijst.Size = new Size(80, 20);
            Keuzelijst.TabIndex = 0;
            Controls.Add(Keuzelijst);
            Keuzelijst.SelectedIndexChanged += Keuzelijst_SelectedIndexChanged;

            // buttons
            OK = new Button
            {
                Location = new Point(370, 55),
                Size = new Size(60, 40),
                Text = "OK",
                BackColor = Color.LightGray
            };

            OK.Click += Knopklik_Click;

            Reset = new Button
            {
                Location = new Point(370, 15),
                Size = new Size(60, 40),
                Text = "Reset Schaal",
                BackColor = Color.LightGray
            };

            Reset.Click += Knopklik_Click;

            // tekstboxen
            MiddenX = new TextBox
            {
                Location = new Point(95, 15),
                Size = new Size(80, 20),
                 Text = "0"
        };
             MiddenY = new TextBox
            {
                Location = new Point(95, 45),
                Size = new Size(80, 30),
                Text = "0",
        };
             Schaal = new TextBox
            {
                Location = new Point(260, 15),
                Size = new Size(100, 30),
                 Text = "0,01"
        };
            Schaalfactor = new TextBox
            {
                Location = new Point(260, 45),
                Size = new Size(100, 30),
                Text = "0,5"
                };
            Max = new TextBox
            {
                Location = new Point(260, 75),
                Size = new Size(100, 30),
                Text = "100"
        };

            this.Controls.Add(OK);
            this.Controls.Add(Reset);
            this.Controls.Add(MiddenX);
            this.Controls.Add(MiddenY);
            this.Controls.Add(Schaal);
            this.Controls.Add(Schaalfactor);
            this.Controls.Add(Max);
        }


    void TekenScherm(object obj, PaintEventArgs pea)
    {
            Graphics gr = pea.Graphics;

            // tekst

        gr.DrawString("midden X:"
            , new Font("Tahoma", 10)
            , Brushes.Black
            , 30, 15
            );
        gr.DrawString("midden Y:"
            , new Font("Tahoma", 10)
            , Brushes.Black
            , 30, 45
            );
        gr.DrawString("schaal:"
            , new Font("Tahoma", 10)
            , Brushes.Black
            , 180, 15
            );
            gr.DrawString("schaalfactor:"
            , new Font("Tahoma", 10)
            , Brushes.Black
            , 180, 45
                );
            gr.DrawString("max:"
            , new Font("Tahoma", 10)
            , Brushes.Black
            , 180, 75
            );
            gr.DrawString("preset:"
            , new Font("Tahoma", 10)
            , Brushes.Black
            , 30, 75
            );
    }
}


class Program
{
        // main methode
    static void Main()
    {
        // maak new form
        MandelForm scherm;
        scherm = new MandelForm();
        Application.Run(scherm);
    }
}
}
