using Domain;
using Helper;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public partial class PersonasRepository: IPersonasRepository
    {        
        public Exception? AgregarPersona(Persona persona)
        {
            try
            {
                using (var contextoBd = new PruebaEvertecContext())
                {
                    //var documento = _mapper.Map<Persona>(persona);
                    contextoBd.Personas.Add(persona);
                    contextoBd.SaveChanges();
                }
                return null;
            }
            catch (Exception ex)
            {
                WriteError.WriteLog(ex.InnerException.Message, ex);
                return ex;
            }
        }

        public List<Persona> ConsultaPersonas()
        {
            List<Persona> persona = new List<Persona>();
            try
            {
                using (var contextoBd = new PruebaEvertecContext())
                {
                    persona = contextoBd.Personas.ToList();
                    return persona; 
                }
            }
            catch (Exception ex)
            {
                WriteError.WriteLog(ex.Message, ex);
                return persona;
            }
        }
        public Exception? ActualizarPersona(Persona persona)
        {
            try
            {
                using (var contextoBd = new PruebaEvertecContext())
                {
                    contextoBd.Entry(persona).State = EntityState.Modified;
                    contextoBd.Entry(persona).Property(x => x.FotoUsuario).IsModified = false;
                    contextoBd.SaveChanges();
                }
                return null;
            }
            catch (Exception ex)
            {
                WriteError.WriteLog(ex.InnerException.Message, ex);
                return ex;
            }
        }

        public Exception? EliminarPersona(int id)
        {
            try
            {
                using (var contextoBd = new PruebaEvertecContext())
                {
                    var persona = contextoBd.Personas.Find(id);
                    contextoBd.Personas.Remove(persona);
                    contextoBd.SaveChanges();
                }
                return null;
            }
            catch (Exception ex)
            {
                WriteError.WriteLog(ex.InnerException.Message, ex);
                return ex;
            }
        }

        public void EliminarPersonaP(int id)
        {
            using (var contextoBd = new PruebaEvertecContext())
            {
                var persona = contextoBd.Personas.Find(id);
                contextoBd.Personas.Remove(persona);
                contextoBd.SaveChanges();
            }
        }


        public Exception? ActualizarFoto(int id, byte[] data)
        {
            try
            {
                using (var contextoBd = new PruebaEvertecContext())
                {
                    var persona = contextoBd.Personas.Find(id);
                    persona.FotoUsuario = data;
                    contextoBd.Entry(persona).State = EntityState.Modified;
                    contextoBd.SaveChanges();
                }
                return null;
            }
            catch (Exception ex)
            {
                WriteError.WriteLog(ex.InnerException.Message, ex);
                return ex;
            }
        }
        public byte[] ObtenerFoto(int id)
        {
            byte[] data = null;
            try
            {
                using (var contextoBd = new PruebaEvertecContext())
                {
                    var persona = contextoBd.Personas.Find(id);
                    data = persona.FotoUsuario;
                }
                return data;
            }
            catch (Exception ex)
            {
                WriteError.WriteLog(ex.InnerException.Message, ex);
                return null;
            }
        }
    }
}
