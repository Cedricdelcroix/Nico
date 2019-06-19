using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApp1.Model
{
    public class Moyen
    {
        public String Text { get; set; }

        public int Weight;

        public Moyen(string text, string weight)
        {
            this.Text = text;
            this.Weight = int.Parse(weight);
        }
    }
}
