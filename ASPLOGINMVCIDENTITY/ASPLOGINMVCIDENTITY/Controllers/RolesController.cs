using ASPLOGINMVCIDENTITY.Models;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ASPLOGINMVCIDENTITY.Controllers
{
    public class RolesController : Controller
    {
        SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        // GET: Roles
        public ActionResult Index()
        {
            return View(GetDataRoles());
        }

        // GET: Roles/Details/5
        public async Task<ActionResult> GetDataRoles()
        {
            var result = await sql.QueryAsync<RoleVM>("EXEC SP_Retrieve_Role");
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Create(RoleVM roleVM)
        {
            var affectedRows = await sql.ExecuteAsync("EXEC SP_Insert_Role @Name", new { Name = roleVM.Name });
            return Json(new { data = affectedRows }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Details(int id)
        {
            var result = await sql.QueryAsync<RoleVM>("EXEC SP_Retrieve_Role_By_Id @Id", new { Id = id });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Edit(RoleVM roleVM)
        {
            var result = await sql.QueryAsync<RoleVM>("EXEC SP_Update_Role @Id, @Name", new { Id = roleVM.Id, Name = roleVM.Name });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var result = await sql.QueryAsync<RoleVM>("EXEC SP_Delete_Role @Id", new { Id = id });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
    }
}
