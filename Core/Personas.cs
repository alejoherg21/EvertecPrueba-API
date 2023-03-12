using Domain;

namespace Core
{
    public class Personas: IPersonas
    {
        private readonly IPersonasRepository personasRepository;

        //private readonly PruebaEvertecContext _context;
        public Personas(IPersonasRepository personasRepository)
        {
            this.personasRepository = personasRepository;
        }
        public Exception AgregarPersona(Persona persona)
        {
            try
            {
                //aca se ejecuta toda la logica del negocio
                Exception respuesta = personasRepository.AgregarPersona(persona);
                return respuesta;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public List<Persona> ConsultarPersonas()
        {
            List<Persona> persona = new List<Persona>();
            try
            {
                //aca se ejecuta toda la logica del negocio
                persona = personasRepository.ConsultaPersonas();
                return persona;
            }
            catch (Exception ex)
            {
                return persona;
            }
        }

        public Exception ActualizarPersona(Persona persona)
        {
            try
            {
                //aca se ejecuta toda la logica del negocio
                Exception respuesta = personasRepository.ActualizarPersona(persona);
                return respuesta;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public Exception EliminarPersona(int id)
        {
            try
            {
                //aca se ejecuta toda la logica del negocio
                Exception respuesta = personasRepository.EliminarPersona(id);
                return respuesta;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public void EliminarPersonaP(int id)
        {
                //aca se ejecuta toda la logica del negocio
                personasRepository.EliminarPersonaP(id);
        }

        public Exception ActualizarFoto(int id, byte[] data)
        {
            try
            {
                //aca se ejecuta toda la logica del negocio
                Exception respuesta = personasRepository.ActualizarFoto(id, data);
                return respuesta;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public byte[] ObtenerFoto(int id)
        {
            byte[] data= null;
            try
            {
                //aca se ejecuta toda la logica del negocio
                data = personasRepository.ObtenerFoto(id);
                return data;
            }
            catch (Exception ex)
            {
                return data;
            }
        }
    }
}
