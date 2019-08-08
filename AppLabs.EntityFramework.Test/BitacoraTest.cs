using System.Linq;
using System.Threading.Tasks;
using AppLabs.EntityFramework.Data;
using AppLabs.EntityFramework.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppLabs.EntityFramework.Test
{
    [TestClass]
    public class BitacoraTest
    {
        private BitacoraContext _context;
        private DatabaseFactory<BitacoraContext> _factory;
        private UnitOfWork _uow;

        [TestInitialize]
        public void Initialize()
        {
            //La cadena de conexion no aplica puesto que
            //estamos usando una base de datos en memoria.
            _factory = new DatabaseFactory<BitacoraContext>
                (new DataAccessConfiguration("Data Source=C:\\DEV\\bitacora.db", true));
            _uow = new UnitOfWork(_factory);
            InitProyectos();
            InitEtiquetas();
        }

        private void InitProyectos()
        {
            var proyectoRepo = _uow.GetRepository<Proyecto>();

            var list = proyectoRepo.GetMany(p => p.ProyectoId == 1 || p.ProyectoId == 2).ToList();

            if (list.Count > 0) return;

            proyectoRepo.Add(new Proyecto
                {
                    ProyectoId = 1,
                    Nombre = "Estudiar Estadistica",
                    Descripcion = "Terminar el curso básico"
                });

            proyectoRepo.Add(
                new Proyecto
                {
                    ProyectoId = 2,
                    Nombre = "Estudiar Oratoria",
                    Descripcion = "Terminar Oratoria"
                });

            _uow.Save();
        }

        private void InitEtiquetas()
        {
            var etiquetaRepo = _uow.GetRepository<Etiqueta>();

            var list = etiquetaRepo.GetMany(e => e.EtiquetaId == 1 
                                                 || e.EtiquetaId == 2
                                                 || e.EtiquetaId == 3).ToList();

            if (list.Count > 0) return;

            etiquetaRepo.Add(new Etiqueta
            {
                EtiquetaId = 1,
                Nombre = "Compra",
                Descripcion = "Comprar un recurso"
            });

            etiquetaRepo.Add(
                new Etiqueta
                {
                    EtiquetaId = 2,
                    Nombre = "Estudiar",
                    Descripcion = "Estudiar un recurso"
                });

            etiquetaRepo.Add(
                new Etiqueta
                {
                    EtiquetaId = 3,
                    Nombre = "Certificación",
                    Descripcion = "Presentar examén de certificación"
                });

            _uow.Save();
        }

        [TestMethod]
        public  async Task GetProyectos()
        {
            var proyectosRepo = _uow.GetRepository<Proyecto>();

            var results = await proyectosRepo.GetAllAsync();

            Assert.IsTrue(results.ToList().Count > 0);
        }

        [TestMethod]
        public async Task CreateProyecto()
        {
            var proyectosRepo = _uow.GetRepository<Proyecto>();

            var ultimoProyecto = proyectosRepo.GetAll().OrderByDescending(p => p.ProyectoId).FirstOrDefault();
            int sigId = 1;

            if (ultimoProyecto != null)
            {
                sigId = ultimoProyecto.ProyectoId + 1;
            }


            var result = await proyectosRepo.AddAsync(new Proyecto
            {
                ProyectoId = sigId,
                Nombre = "Pagina web",
                Descripcion = "Crear una pagina web"
            });

            Assert.IsNotNull(result);

            var saved = _uow.Save();
            Assert.AreEqual(1, saved);
        }


        [TestMethod]
        public async Task DeleteProyecto()
        {
            var proyectosRepo = _uow.GetRepository<Proyecto>();

            var result = await proyectosRepo.AddAsync(new Proyecto
            {
                ProyectoId = 99,
                Nombre = "Pagina web",
                Descripcion = "Crear una pagina web"
            });

            Assert.IsNotNull(result);

            var saved = _uow.Save();
            Assert.AreEqual(1, saved);


            proyectosRepo.Delete(p => p.ProyectoId == 99);

            var deleted = _uow.Save();
            Assert.AreEqual(1, saved);

            var results = proyectosRepo.GetMany(p => p.ProyectoId == 99);

            Assert.AreEqual(0, results.ToList().Count);
        }

    }
}
