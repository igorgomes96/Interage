﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class EventoDto
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O nome do evento precisa ser informado!")]
        [StringLength(80, ErrorMessage = "O nome do evento pode ter no máximo 80 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Uma descrição para o evento precisa ser informado!")]
        [StringLength(255, ErrorMessage = "A descrição do evento pode ter no máximo 255 caracteres!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A área de interesse do evento precisa ser informada!")]
        public int CodAreaInteresse { get; set; }

        [Required(ErrorMessage = "A data de início do evento precisa ser informada!")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A data de encerramento do evento precisa ser informada!")]
        public DateTime DataFim { get; set; }

        [StringLength(80, ErrorMessage = "O email do promotor pode ter no máximo 80 caracteres!")]
        [Required(ErrorMessage = "O email do promotor do evento precisa ser informado!")]
        public string EmailUsuarioPromotor { get; set; }

        public int CodEndereco { get; set; }


        [Required(ErrorMessage = "É preciso informar se o evento será no seu endereço ou em outro local.")]
        public bool FlagEnderecoPromotor { get; set; }


        public AreaInteresseDto AreaInteresse { get; set; }
        public EnderecoDto Endereco { get; set; }
        public UsuarioDto Promotor { get; set; }
    }
}