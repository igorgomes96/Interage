using InterageApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Services.Interfaces
{
    public interface IUsuariosService
    {

        /// <summary>
        /// Faz o cadastro no Interage
        /// </summary>
        /// <param name="usuario">Usuário a se cadastrar</param>
        /// <returns>Usuário com o Token</returns>
        UsuarioDto Cadastrar(UsuarioCredenciaisDto usuario);

        /// <summary>
        /// Exclui o cadastro de um usuário do Interage
        /// </summary>
        /// <param name="emailUsuario">Email do Usuário a ser excluído</param>
        /// <returns>Usuário excluído</returns>
        UsuarioDto ExcluirCadastro(string emailUsuario);

        /// <summary>
        /// Retorna o usuário.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        UsuarioDto BuscaUsuario(string email);


    }
}
