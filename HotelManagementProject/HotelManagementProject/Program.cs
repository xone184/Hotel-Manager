using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementProject
{
    static class Program
    {
        public static frmLogin loginForm = null;
        public static FrmMain mainForm = null;
        public static frmService serviceForm = null;
        public static frmDevice deviceForm = null;
        public static frmCustomer customerForm = null;
        public static frmBooking bookingForm = null;
        public static frmBookingOnline bookingOnlineForm = null;
        public static frmRoom roomForm = null;
        public static frmBill billForm = null;
        public static frmStaff staffForm = null;
        public static frmBillStatistics billStatisticsForm = null;
        public static frmBillStatisticsService billStatisticsServiceForm = null;
        public static frmBillStatisticsDevice billStatisticsDeviceForm = null;
        public static frmAccount accountForm = null;
        public static frmChangePassword changePasswordForm = null;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
