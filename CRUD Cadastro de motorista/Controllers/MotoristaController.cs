using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using CRUD_Cadastro_de_motorista.Models;
using System.Web.Http;

namespace CRUD_Cadastro_de_motorista.Controllers
{
    public class MotoristaController : ApiController
    {
        cmEntities cm = new cmEntities();
        public IHttpActionResult getemp()
        {
           
            var results = cm.Newmotoristas.ToList();
            return Ok(results);
        }

        [HttpPost]
        public IHttpActionResult motinsert(Newmotorista motinsert)
        {
            cm.Newmotoristas.Add(motinsert);
            cm.SaveChanges();
            return Ok();
      
        }

        public IHttpActionResult GetIdMot(int id)
        {
            Motorista details = null;
            details = cm.Newmotoristas.Where(x => x.Motid == id).Select(x => new Motorista()
            {
                Motid = x.Motid,
                Motnome = x.Motnome,
                Motsobrenome = x.Motsobrenome,
                Motcaminhao = x.Motcaminhao,
                Motendereco = x.Motendereco,
                Motmarca = x.Motmarca,
                Motmodelo = x.Motmodelo,
                Motnumcaminhao = x.Motnumcaminhao,
                Moteixos = x.Moteixos

            }).FirstOrDefault<Motorista>();
            if (details == null)
            {
                return NotFound();
            }
            return Ok(details);
        }

        public IHttpActionResult Put(Motorista mt)
        {
            var uptatemp = cm.Newmotoristas.Where(x => x.Motid == mt.Motid).FirstOrDefault<Newmotorista>();
            if (uptatemp != null)
            {
                uptatemp.Motid = mt.Motid;
                uptatemp.Motnome = mt.Motnome;
                uptatemp.Motsobrenome = mt.Motsobrenome;
                uptatemp.Motcaminhao = mt.Motcaminhao;
                uptatemp.Motendereco = mt.Motendereco;
                uptatemp.Motmarca = mt.Motmarca;
                uptatemp.Motmodelo = mt.Motmodelo;
                uptatemp.Motnumcaminhao = mt.Motnumcaminhao;
                uptatemp.Moteixos = mt.Moteixos;
                cm.SaveChanges();     
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var empmodel = cm.Newmotoristas.Where(x => x.Motid == id).FirstOrDefault();
            cm.Entry(empmodel).State = System.Data.Entity.EntityState.Deleted;
            cm.SaveChanges();

            return Ok();
        }
    }
}
