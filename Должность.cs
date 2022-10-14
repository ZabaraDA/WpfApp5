using System;
using System.Collections.Generic;

namespace WpfApp5
{
    public partial class Должность
    {
        public Должность()
        {
            Пользовательs = new HashSet<Пользователь>();
        }

        public int Код { get; set; }
        public string? Наименование { get; set; }

        public virtual ICollection<Пользователь> Пользовательs { get; set; }
    }
}
