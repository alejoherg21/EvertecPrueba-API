using Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IPersonasRepository
    {
        Exception AgregarPersona(Persona persona);
        List<Persona> ConsultaPersonas();
        Exception ActualizarPersona(Persona persona);
        Exception EliminarPersona(int id);
        Exception ActualizarFoto(int id, byte[] data);
        byte[] ObtenerFoto(int id);
    }
}
