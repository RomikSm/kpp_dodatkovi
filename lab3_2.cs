using System;
using System.Windows.Forms;

public class HelloForm
{
    public static int Main()
    {
        Form fm = new Form();
        fm.Text = "Моя форма";
        fm.Width = 300;
        fm.Height = 200;

        Button btn = new Button();
        btn.Text = "Тикни сюди";
        btn.Width = 100;
        btn.Height = 50;
        btn.Left = (fm.ClientSize.Width - btn.Width) / 2;
        btn.Top = (fm.ClientSize.Height - btn.Height) / 2;

        btn.Click += (sender, e) => { fm.Close(); };
        fm.Controls.Add(btn);
        Application.Run(fm);
        return 0;
    }
}
