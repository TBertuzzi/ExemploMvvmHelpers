using System;
using System.Collections.Generic;
using ExemploMvvmHelpers.Model;

namespace ExemploMvvmHelpers.Services
{
    public class UsuarioService
    {
        public List<Usuario> ObterUsuarios()
        {
            var usuarios = new List<Usuario>();

            usuarios.Add(new Usuario
            {
                Nome= "Bertuzzi",
                Email = "bertuzzi@bertuzzi.com.br"
            });

            usuarios.Add(new Usuario
            {
                Nome = "Bruna",
                Email = "bruna@bruna.com.br"
            });

            usuarios.Add(new Usuario
            {
                Nome = "Polly",
                Email = "polly@polly.com.br"
            });

            return usuarios;
        }
    }
}
