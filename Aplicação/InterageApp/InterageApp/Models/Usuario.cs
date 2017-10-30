using System;
using System.Collections.Generic;

namespace InterageApp.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Eventos = new HashSet<Evento>();
            ExpositoresAtividade = new HashSet<ExpositorAtividade>();
            Feedbacks = new HashSet<Feedback>();
            SalasDiscussao = new HashSet<SalaDiscussao>();
            UsuariosInteresses = new HashSet<UsuarioInteresse>();
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public int CodigoPerfil { get; set; }

        public Perfil Perfil { get; set; }
        public EnderecoUsuario EnderecoUsuario { get; set; }
        public Credenciais Credenciais { get; set; }
        public ICollection<Evento> Eventos { get; set; }
        public ICollection<ExpositorAtividade> ExpositoresAtividade { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<SalaDiscussao> SalasDiscussao { get; set; }
        public ICollection<UsuarioInteresse> UsuariosInteresses { get; set; }
    }
}
