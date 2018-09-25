using System;
using MvvmHelpers;

namespace ExemploMvvmHelpers.Model
{
    public class Usuario : ObservableObject
    {
        string _nome;
        public string Nome 
        {
            get
            {
                return _nome;
            }
            set
            {
                if(SetProperty(ref _nome, value))
                {
                    //Executar Ação
                }
                else
                {
                    //Executar Else
                }
            }
        }

        string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                SetProperty(ref _email, value);
            }
        }

        public string NomeAgrupado => Nome[0].ToString();
    }
}
