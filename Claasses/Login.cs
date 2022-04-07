using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectAvanzada.Models;
namespace ProyectAvanzada.Claasses
{
    public class Login
    {
        public string EMAIL { get; set; }
        public string PASWORD { get; set; }


        PrograAvanzadaProyectoEntities db = new PrograAvanzadaProyectoEntities();

        public bool Autenticacion()
        {
          
            if (db.USUARIO.Where(u => u.EMAIL == this.EMAIL && u.PASWORD == this.PASWORD).FirstOrDefault() != null)
            {
                return true;
            }

            return false;




        }



    }
}