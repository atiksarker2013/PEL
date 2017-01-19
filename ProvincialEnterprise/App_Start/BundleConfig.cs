using System.Web;
using System.Web.Optimization;

namespace ProvincialEnterprise
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new ScriptBundle("~/bundles/angularJS").Include(
                 "~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/CustomJS").Include(
                "~/Custom/Company/companyModule.js",
                "~/Custom/Company/companyService.js",
                "~/Custom/Company/companyController.js",
                 "~/Custom/Branch/branchModule.js",
                 "~/Custom/Branch/branchService.js",
                 "~/Custom/Branch/branchController.js",
                 "~/Custom/Section/sectionModule.js",
                 "~/Custom/Section/sectionService.js",
                 "~/Custom/Section/sectionController.js",
                 "~/Custom/Designation/designationModule.js",
                 "~/Custom/Designation/designationService.js",
                 "~/Custom/Designation/designationController.js",
                 "~/Custom/Marketing/marketingModule.js",
                 "~/Custom/Marketing/marketingService.js",
                 "~/Custom/Marketing/marketingController.js",
                 "~/Custom/MainHead/mainHeadModule.js",
                 "~/Custom/MainHead/mainHeadService.js",
                 "~/Custom/MainHead/mainHeadController.js",
                 "~/Custom/Ledger/accountModule.js",
                 "~/Custom/Ledger/accountService.js",
                 "~/Custom/Ledger/accountController.js",
                 "~/Custom/Bank/bankModule.js",
                 "~/Custom/Bank/bankService.js",
                 "~/Custom/Bank/bankController.js",
                 "~/Custom/CustomerBank/customerBankModule.js",
                 "~/Custom/CustomerBank/customerBankService.js",
                 "~/Custom/CustomerBank/customerBankController.js",
                 "~/Custom/Supplier/supplierModule.js",
                 "~/Custom/Supplier/supplierService.js",
                 "~/Custom/Supplier/supplierController.js",
                 "~/Custom/CCLimit/cclimitModule.js",
                 "~/Custom/CCLimit/cclimitService.js",
                 "~/Custom/CCLimit/cclimitController.js",
                 "~/Custom/Unit/unitModule.js",
                 "~/Custom/Unit/unitService.js",
                 "~/Custom/Unit/unitController.js",
                 "~/Custom/Customer/customerModule.js",
                 "~/Custom/Customer/customerService.js",
                 "~/Custom/Customer/customerController.js",
                 "~/Custom/Item/itemModule.js",
                 "~/Custom/Item/itemService.js",
                 "~/Custom/Item/itemController.js",
                 "~/Custom/Model/modelModule.js",
                 "~/Custom/Model/modelService.js",
                 "~/Custom/Model/modelController.js",
                 "~/Custom/Purchase/purchaseModule.js",
                 "~/Custom/Purchase/purchaseService.js",
                 "~/Custom/Purchase/purchaseController.js",
                 "~/Custom/PurchaseDetail/purchaseDetailModule.js",
                 "~/Custom/PurchaseDetail/purchaseDetailService.js",
                 "~/Custom/PurchaseDetail/purchaseDetailController.js",
                 "~/Custom/OpeningStock/openingStockModule.js",
                 "~/Custom/OpeningStock/openingStockService.js",
                 "~/Custom/OpeningStock/openingStockController.js"));

        }
    }
}
