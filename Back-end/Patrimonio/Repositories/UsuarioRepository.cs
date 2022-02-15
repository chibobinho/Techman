using Patrimonio.Contexts;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonio.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly PatrimonioContext ctx;

        public UsuarioRepository(PatrimonioContext appContext)
        {
            ctx = appContext;
        }

        public Usuario Login(string email, string senha)
        {
            //var usuarioEncontrado = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            //if (usuarioEncontrado != null)
            //{
            //    bool comparado = Criptografia.Comparar(senha, usuarioEncontrado.Senha);
            //    if (comparado)
            //    {
            //        return usuarioEncontrado;
            //    }
            //    else
            //    {
            //        usuarioEncontrado.Senha = Criptografia.GerarHash(usuarioEncontrado.Senha);
            //        comparado = Criptografia.Comparar(senha, usuarioEncontrado.Senha);
            //        if (comparado)
            //        {
            //            ctx.Usuarios.Update(usuarioEncontrado);
            //            ctx.SaveChanges();
            //            return usuarioEncontrado;
            //        }
            //        else
            //        {
            //            return null;
            //        }
            //    }
            //}

            //return null;

            Usuario usuarioEncontrado = ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.Senha = Criptografia.GerarHash(usuarioEncontrado.Senha);
                ctx.Usuarios.Update(usuarioEncontrado);
                ctx.SaveChanges();

                return usuarioEncontrado;
            }

            else
            {
                usuarioEncontrado = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

                if (usuarioEncontrado != null)
                {
                    if (Criptografia.Comparar(senha, usuarioEncontrado.Senha))
                    {
                        return usuarioEncontrado;
                    }
                }
            }

            return null;
        }
    }
}
