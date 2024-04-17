using Examen.Domain.Entities.Examen;
using Examen.Domain.Interfaces.Repositories.Examen;
using Examen.Domain.Interfaces.Repositories.Medicamentos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infraestructure.Repositories.Medicamento
{
    public class MedicamentoRepository : IMedicamentos
    {
        private readonly ExamenContext _dbContext;
        public MedicamentoRepository(ExamenContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<ResponseMedicamentos>> GetAllMedicineByFiltro(Med request)
        {
            List<ResponseMedicamentos>? oResponse = [];
            try
            {
                var oQuery = from Med in _dbContext.Medicamentos
                             join FMed in _dbContext.formasfarmaceuticas
                             on Med.idformafarmaceutica equals FMed.idformafarmaceutica
                             select new
                             {
                                 med = Med,
                                 fMed = FMed
                             };               
                var oRegistros = await oQuery.Where(src=> src.med == request).ToListAsync();

                foreach (var item in oRegistros)
                {
                    ResponseMedicamentos oResp = new ResponseMedicamentos();
                    oResp.idmedicamento = item.med.idmedicamento;
                    oResp.nombre = item.med.nombre;
                    oResp.concentracion = item.med.concentracion;
                    oResp.idformafarmaceutica = item.med.idformafarmaceutica;
                    oResp.precio = item.med.precio;
                    oResp.stock = item.med.stock;
                    oResp.presentacion = item.med.presentacion;
                    oResp.bhabilitado = item.med.bhabilitado;
                    oResp.idffarmaceutica = item.fMed.idformafarmaceutica;
                    oResp.nombreF = item.fMed.nombre;
                    oResp.habilitado = item.fMed.habilitado;

                    oResponse.Add(oResp);
                }
                return oResponse;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }
        public async Task<List<ResponseMedicamentos>> GetAllMedicine(int PageNumber, int PageSize)
        {
            List<ResponseMedicamentos>? oResponse = [];
            try
            {
                var oQuery = from Med in _dbContext.Medicamentos
                             join FMed in _dbContext.formasfarmaceuticas
                             on Med.idformafarmaceutica equals FMed.idformafarmaceutica
                             select new {
                                 med = Med,
                                 fMed = FMed
                             };

                var oRegistros = oQuery.Skip((PageNumber - 1) * PageSize).Take(PageSize);


                foreach (var item in oRegistros)
                {
                    ResponseMedicamentos oResp = new ResponseMedicamentos();
                    oResp.idmedicamento = item.med.idmedicamento;
                    oResp.nombre = item.med.nombre;
                    oResp.concentracion = item.med.concentracion;
                    oResp.idformafarmaceutica = item.med.idformafarmaceutica;
                    oResp.precio = item.med.precio;
                    oResp.stock = item.med.stock;
                    oResp.presentacion = item.med.presentacion;
                    oResp.bhabilitado = item.med.bhabilitado;
                    oResp.idffarmaceutica = item.fMed.idformafarmaceutica;
                    oResp.nombreF = item.fMed.nombre;
                    oResp.habilitado = item.fMed.habilitado;

                    oResponse.Add(oResp);
                }
                return oResponse;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public async Task<Med> AddMedicine(Med Medicine)
        {
            Med oResponse = new Med();
            await _dbContext.Medicamentos.AddAsync(Medicine);
            var iRes = _dbContext.SaveChanges();
            if (iRes != null)
            {
                return oResponse;
            }
            else
            {
                throw new ArgumentException("#No se agrego el registro");
            }


        }

        public async Task<Med> ModMedicine(Med Medicine)
        {
            Med oResponse = new Med();
            Med? Medic = null;
            Medic = await _dbContext.Medicamentos.FirstOrDefaultAsync(src => src.idmedicamento == Medicine.idmedicamento);
            if (Medic != null)
            {

                Medic.idmedicamento = Medicine.idmedicamento;
                Medic.nombre = Medicine.nombre;
                Medic.concentracion = Medicine.concentracion;
                Medic.idformafarmaceutica = Medicine.idformafarmaceutica;
                Medic.precio = Medicine.precio;
                Medic.stock = Medicine.stock;
                Medic.presentacion = Medicine.presentacion;
                Medic.bhabilitado = Medicine.bhabilitado;


                var iRes = await _dbContext.SaveChangesAsync();
                oResponse.idmedicamento = Medicine.idmedicamento;
                if (iRes == 0) { throw new ArgumentException("#No se Actualizo el registro"); }

            }
            else
            {
                throw new ArgumentException("#No existe ese Usuario");
            }

            return oResponse;
        }

        public async Task<Med> DelMedicine(string user)
        {
            Med oResponse = new Med();
            var oReqBase = await _dbContext.Medicamentos.FirstOrDefaultAsync(src => src.idmedicamento == Convert.ToInt16(user));
            if (oReqBase != null)
            {
                _dbContext.Medicamentos.Remove(oReqBase);
                var iRes = _dbContext.SaveChanges();
                if (iRes == null) { throw new ArgumentException("#No se Elimino el registro"); }
            }
            else
            {
                throw new ArgumentException("#No existe ese Medicamento");
            }

            return oResponse;
        }
    }
}
