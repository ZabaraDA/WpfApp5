using System;
using System.Collections.Generic;

namespace WpfApp5
{
    public partial class Пользователь
    {
        public int Код { get; set; }
        public string Имя { get; set; } = null!;
        public string Фамилия { get; set; } = null!;
        public string Отчество { get; set; } = null!;
        public int КодПользователя { get; set; }

        public virtual Должность Должность { get; set; } = null!;
    }
}
