﻿namespace PessoasApi.Model
{
    using System;

    public class PessoaFisica : Pessoa
    {
        public override string Tipo => "Fisica";
        public DateTime Nascimento { get; set; }
        public string Cpf { get; set; }
        public DadosSaude DadosSaude { get; set; }

        
    }

    public class DadosSaude
    {
        public bool Fumante { get; set; }
        public bool PraticaEsporte { get; set; }

    }

}
