using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUL;
using CAL;
using BAL;
using DBL;
using System.IO;
using System.Xml;
using DBL.DBHELPER;


namespace WindowsWLEDI
{
    public partial class Form1 : Form
    { private IniFile myIni;
    string strXml,ov_xml_str;
        public Form1()
        {
            InitializeComponent();
        }
        public class DataToXml
        {

            /**/
            /// <summary> 

            /// 将DataTable对象转换成XML字符串 

            /// </summary> 

            /// <param name="dt">DataTable对象</param> 

            /// <returns>XML字符串</returns> 

            public static string CDataToXml(DataTable dt)
            {

                if (dt != null)
                {

                    MemoryStream ms = null;

                    XmlTextWriter XmlWt = null;

                    try
                    {

                        ms = new MemoryStream();

                        //根据ms实例化XmlWt 

                        XmlWt = new XmlTextWriter(ms, Encoding.Unicode);

                        //获取ds中的数据 

                        dt.WriteXml(XmlWt);

                        int count = (int)ms.Length;

                        byte[] temp = new byte[count];

                        ms.Seek(0, SeekOrigin.Begin);

                        ms.Read(temp, 0, count);

                        //返回Unicode编码的文本 

                        UnicodeEncoding ucode = new UnicodeEncoding();

                        string returnValue = ucode.GetString(temp).Trim();

                        return returnValue;

                    }

                    catch (System.Exception ex)
                    {

                        throw ex;

                    }

                    finally
                    {

                        //释放资源 

                        if (XmlWt != null)
                        {

                            XmlWt.Close();

                            ms.Close();

                            ms.Dispose();

                        }

                    }

                }

                else
                {

                    return "";

                }

            }

            /**/
            /// <summary> 

            /// 将DataSet对象中指定的Table转换成XML字符串 

            /// </summary> 

            /// <param name="ds">DataSet对象</param> 

            /// <param name="tableIndex">DataSet对象中的Table索引</param> 

            /// <returns>XML字符串</returns> 

            public static string CDataToXml(DataSet ds, int tableIndex)
            {

                if (tableIndex != -1)
                {

                    return CDataToXml(ds.Tables[tableIndex]);

                }

                else
                {

                    return CDataToXml(ds.Tables[0]);

                }

            }

            /**/
            /// <summary> 

            /// 将DataSet对象转换成XML字符串 

            /// </summary> 

            /// <param name="ds">DataSet对象</param> 

            /// <returns>XML字符串</returns> 

            public static string CDataToXml(DataSet ds)
            {

                return CDataToXml(ds, -1);

            }

            /**/
            /// <summary> 

            /// 将DataView对象转换成XML字符串 

            /// </summary> 

            /// <param name="dv">DataView对象</param> 

            /// <returns>XML字符串</returns> 

            public static string CDataToXml(DataView dv)
            {

                return CDataToXml(dv.Table);

            }

            /**/
            /// <summary> 

            /// 将DataSet对象数据保存为XML文件 

            /// </summary> 

            /// <param name="dt">DataSet</param> 

            /// <param name="xmlFilePath">XML文件路径</param> 

            /// <returns>bool值</returns> 

            public static bool CDataToXmlFile(DataTable dt, string xmlFilePath)
            {

                if ((dt != null) && (!string.IsNullOrEmpty(xmlFilePath)))
                {

                    // string path = HttpContext.Current.Server.MapPath(xmlFilePath); 
                   // string path = "";
                    MemoryStream ms = null;

                    XmlTextWriter XmlWt = null;

                    try
                    {

                        ms = new MemoryStream();

                        //根据ms实例化XmlWt 

                        XmlWt = new XmlTextWriter(ms, Encoding.Unicode);

                        //获取ds中的数据 

                        dt.WriteXml(XmlWt);

                        int count = (int)ms.Length;

                        byte[] temp = new byte[count];

                        ms.Seek(0, SeekOrigin.Begin);

                        ms.Read(temp, 0, count);

                        //返回Unicode编码的文本 

                        UnicodeEncoding ucode = new UnicodeEncoding();

                        //写文件 

                        StreamWriter sw = new StreamWriter(xmlFilePath);

                        //   sw.WriteLine("<?xml version="1.0" encoding="utf-8"?>"); 

                        sw.WriteLine(ucode.GetString(temp).Trim());

                        sw.Close();

                        return true;

                    }

                    catch (System.Exception ex)
                    {

                        throw ex;

                    }

                    finally
                    {

                        //释放资源 

                        if (XmlWt != null)
                        {

                            XmlWt.Close();

                            ms.Close();

                            ms.Dispose();

                        }

                    }

                }

                else
                {

                    return false;

                }

            }

            /**/
            /// <summary> 

            /// 将DataSet对象中指定的Table转换成XML文件 

            /// </summary> 

            /// <param name="ds">DataSet对象</param> 

            /// <param name="tableIndex">DataSet对象中的Table索引</param> 

            /// <param name="xmlFilePath">xml文件路径</param> 

            /// <returns>bool]值</returns> 

            public static bool CDataToXmlFile(DataSet ds, int tableIndex, string xmlFilePath)
            {

                if (tableIndex != -1)
                {

                    return CDataToXmlFile(ds.Tables[tableIndex], xmlFilePath);

                }

                else
                {

                    return CDataToXmlFile(ds.Tables[0], xmlFilePath);

                }

            }

            /**/
            /// <summary> 

            /// 将DataSet对象转换成XML文件 

            /// </summary> 

            /// <param name="ds">DataSet对象</param> 

            /// <param name="xmlFilePath">xml文件路径</param> 

            /// <returns>bool]值</returns> 

            public static bool CDataToXmlFile(DataSet ds, string xmlFilePath)
            {

                return CDataToXmlFile(ds, -1, xmlFilePath);

            }

            /**/
            /// <summary> 

            /// 将DataView对象转换成XML文件 

            /// </summary> 

            /// <param name="dv">DataView对象</param> 

            /// <param name="xmlFilePath">xml文件路径</param> 

            /// <returns>bool]值</returns> 

            public static bool CDataToXmlFile(DataView dv, string xmlFilePath)
            {

                return CDataToXmlFile(dv.Table, xmlFilePath);

            }

        }

        /**/
        /// <summary> 

        /// XML形式的字符串、XML文江转换成DataSet、DataTable格式 

        /// </summary> 

        public class XmlToData
        {

            /**/
            /// <summary> 

            /// 将Xml内容字符串转换成DataSet对象 

            /// </summary> 

            /// <param name="xmlStr">Xml内容字符串</param> 

            /// <returns>DataSet对象</returns> 

            public static DataSet CXmlToDataSet(string xmlStr)
            {

                if (!string.IsNullOrEmpty(xmlStr))
                {

                    StringReader StrStream = null;

                    XmlTextReader Xmlrdr = null;

                    try
                    {

                        DataSet ds = new DataSet();

                        //读取字符串中的信息 

                        StrStream = new StringReader(xmlStr);

                        //获取StrStream中的数据 

                        Xmlrdr = new XmlTextReader(StrStream);

                        //ds获取Xmlrdr中的数据 

                        ds.ReadXml(Xmlrdr);

                        return ds;

                    }

                    catch (Exception e)
                    {

                        throw e;

                    }

                    finally
                    {

                        //释放资源 

                        if (Xmlrdr != null)
                        {

                            Xmlrdr.Close();

                            StrStream.Close();

                            StrStream.Dispose();

                        }

                    }

                }

                else
                {

                    return null;

                }

            }

            /**/
            /// <summary> 

            /// 将Xml字符串转换成DataTable对象 

            /// </summary> 

            /// <param name="xmlStr">Xml字符串</param> 

            /// <param name="tableIndex">Table表索引</param> 

            /// <returns>DataTable对象</returns> 

            public static DataTable CXmlToDatatTable(string xmlStr, int tableIndex)
            {

                return CXmlToDataSet(xmlStr).Tables[tableIndex];

            }

            /**/
            /// <summary> 

            /// 将Xml字符串转换成DataTable对象 

            /// </summary> 

            /// <param name="xmlStr">Xml字符串</param> 

            /// <returns>DataTable对象</returns> 

            public static DataTable CXmlToDatatTable(string xmlStr)
            {

                return CXmlToDataSet(xmlStr).Tables[0];

            }

            /**/
            /// <summary> 

            /// 读取Xml文件信息,并转换成DataSet对象 

            /// </summary> 

            /// <remarks> 

            /// DataSet ds = new DataSet(); 

            /// ds = CXmlFileToDataSet("/XML/upload.xml"); 

            /// </remarks> 

            /// <param name="xmlFilePath">Xml文件地址</param> 

            /// <returns>DataSet对象</returns> 

            public static DataSet CXmlFileToDataSet(string xmlFilePath)
            {

                if (!string.IsNullOrEmpty(xmlFilePath))
                {

                    // string path = HttpContext.Current.Server.MapPath(xmlFilePath);
                    string path = "";
                    StringReader StrStream = null;

                    XmlTextReader Xmlrdr = null;

                    try
                    {

                        XmlDocument xmldoc = new XmlDocument();

                        //根据地址加载Xml文件 

                        xmldoc.Load(path);

                        DataSet ds = new DataSet();

                        //读取文件中的字符流 

                        StrStream = new StringReader(xmldoc.InnerXml);

                        //获取StrStream中的数据 

                        Xmlrdr = new XmlTextReader(StrStream);

                        //ds获取Xmlrdr中的数据 

                        ds.ReadXml(Xmlrdr);

                        return ds;

                    }

                    catch (Exception e)
                    {

                        throw e;

                    }

                    finally
                    {

                        //释放资源 

                        if (Xmlrdr != null)
                        {

                            Xmlrdr.Close();

                            StrStream.Close();

                            StrStream.Dispose();

                        }

                    }

                }

                else
                {

                    return null;

                }

            }

            /**/
            /// <summary> 

            /// 读取Xml文件信息,并转换成DataTable对象 

            /// </summary> 

            /// <param name="xmlFilePath">xml文江路径</param> 

            /// <param name="tableIndex">Table索引</param> 

            /// <returns>DataTable对象</returns> 

            public static DataTable CXmlToDataTable(string xmlFilePath, int tableIndex)
            {

                return CXmlFileToDataSet(xmlFilePath).Tables[tableIndex];

            }

            /**/
            /// <summary> 

            /// 读取Xml文件信息,并转换成DataTable对象 

            /// </summary> 

            /// <param name="xmlFilePath">xml文江路径</param> 

            /// <returns>DataTable对象</returns> 

            public static DataTable CXmlToDataTable(string xmlFilePath)
            {

                return CXmlFileToDataSet(xmlFilePath).Tables[0];

            }

        }


        // 相应C#代码： 

        private string ConvertDataTableToXML(DataTable xmlDS)
        {

            MemoryStream stream = null;

            XmlTextWriter writer = null;

            try
            {

                stream = new MemoryStream();

                writer = new XmlTextWriter(stream, Encoding.Default);

                xmlDS.WriteXml(writer);

                int count = (int)stream.Length;

                byte[] arr = new byte[count];

                stream.Seek(0, SeekOrigin.Begin);

                stream.Read(arr, 0, count);

                UTF8Encoding utf = new UTF8Encoding();

                return utf.GetString(arr).Trim();

            }

            catch
            {

                return String.Empty;

            }

            finally
            {

                if (writer != null) writer.Close();

            }

        }

        private DataSet ConvertXMLToDataSet(string xmlData)
        {

            StringReader stream = null;

            XmlTextReader reader = null;

            try
            {

                DataSet xmlDS = new DataSet();

                stream = new StringReader(xmlData);

                reader = new XmlTextReader(stream);

                xmlDS.ReadXml(reader);

                return xmlDS;

            }

            catch (Exception ex)
            {

                string strTest = ex.Message;

                return null;

            }

            finally
            {

                if (reader != null)

                    reader.Close();

            }

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = BAL.Commone.Get_V_DD_MWORKPLAN1();
            dt.TableName = "BILL";
            dt = BAL.Commone.Get_V_DD_MWORKPLAN("E0008416", "A");
            dt.TableName = "CNTR";
            if (dt == null || dt.Rows.Count == 0) MessageBox.Show("1");
            DataToXml.CDataToXmlFile(dt, @"J:\111.xml");
        }
        public static DataTable Get_ship_info(string iv_ship_no)
        {
            try
            {
               // string str_sql = "SELECT  rownum seq_no,bill_no,null shipper,null consignee,load_port_cod,disc_port_cod," + "'" + "1" + "'" + ",remark_txt,decode(trans_id," + "'" + "1" + "'" + "," + "'" + "T" + "'" + ",null) trans_id FROM ship_bill WHERE ship_No=" + "'" + iv_ship_no + "'";
                string str_sql = "select i_e_id,custom_no,voyage,ship_cod,decode(trade_id," + "'" + "1" + "'" + "," + "'" + "F" + "'" + "," + "'" + "I" + "'" + ") trade_id from ship WHERE ship_No=" + "'" + iv_ship_no + "'";
              
                OracleHelper orc = new OracleHelper();

                return orc.Get_Data(str_sql);
            }
            catch (Exception db_E)
            {
                throw db_E;
            }
        }
        public static DataTable Get_ship_nam(string iv_ship_cod)
        {
            try
            {
                string str_sql = "SELECT  c_ship_nam,e_ship_nam   from c_ship_data where ship_cod="+"'"+iv_ship_cod+"'";
                OracleHelper orc = new OracleHelper();

                return orc.Get_Data(str_sql);
            }
            catch (Exception db_E)
            {
                throw db_E;
            }
        }
        public static DataTable Get_ship_bill(string iv_ship_no)
        {
            try
            {
                string str_sql = "SELECT  rownum seq_no,bill_no,null shipper,null consignee,load_port_cod,disc_port_cod,"+"'"+"1"+"'"+",remark_txt,decode(trans_id,"+"'"+"1"+"'"+","+"'"+"T"+"'"+",null) trans_id FROM ship_bill WHERE ship_No="+"'"+iv_ship_no+"'";

                OracleHelper orc = new OracleHelper();

                return orc.Get_Data(str_sql);
            }
            catch (Exception db_E)
            {
                throw db_E;
            }
        }
        public static DataTable Get_bill_cargo(string iv_ship_no,string iv_bill_no)
        {
            try
            {
                string str_sql = "select cargo_nam,cargo_label,cargo_cross_wgt,cargo_volume  FROM bill_cargo   WHERE ship_No=" + "'" + iv_ship_no + "'" + " and bill_No=" + "'" + iv_bill_no + "'";

                OracleHelper orc = new OracleHelper();

                return orc.Get_Data(str_sql);
            }
            catch (Exception db_E)
            {
                throw db_E;
            }
        }
        public static DataTable Get_bill_cntr(string iv_ship_no,string iv_bill_no)
        {
            try
            {
                string str_sql = "SELECT  rownum seq_no,cntr,bill_no ,cntr_siz_cod,e_f_id,cntr_seal_no FROM bill_cntr   WHERE ship_No=" + "'" + iv_ship_no + "'"+" and bill_No="+"'"+iv_bill_no+"'";

                OracleHelper orc = new OracleHelper();

                return orc.Get_Data(str_sql);
            }
            catch (Exception db_E)
            {
                throw db_E;
            }
        }

        public string gen_xml(string iv_ship_no)
        {
            string wl_time = DateTime.Now.ToString("yyyyMMddHHmmss");
            string wl_bill_num = "1", wl_i_e_id, wl_trade_id, wl_c_ship_nam, wl_e_ship_nam, wl_voyage, wl_custom_no,wl_ship_cod;
            string wl_ship_nam;

            DataTable idt = Get_ship_info(iv_ship_no);
          
            wl_i_e_id = idt.Rows[0]["I_E_ID"].ToString();
            wl_trade_id = idt.Rows[0]["TRADE_ID"].ToString(); 
            wl_voyage = idt.Rows[0]["VOYAGE"].ToString();
            wl_custom_no = idt.Rows[0]["CUSTOM_NO"].ToString();
            wl_ship_cod = idt.Rows[0]["SHIP_COD"].ToString();


            DataTable sdt = Get_ship_nam(wl_ship_cod);
             
            wl_c_ship_nam = sdt.Rows[0]["C_SHIP_NAM"].ToString();
            wl_e_ship_nam = sdt.Rows[0]["E_SHIP_NAM"].ToString(); 

            DataTable dt = Get_ship_bill(iv_ship_no);
            wl_bill_num = dt.Rows.Count.ToString();

            if (dt == null || dt.Rows.Count == 0) return "*";
            ov_xml_str = "<?xml version=\"1.0\" encoding=\"GB2312\"?>";
            ov_xml_str = ov_xml_str + "<MESSAGE>";
            ov_xml_str = ov_xml_str + "  <MESSAGE_ID>EPIFCSUM</MESSAGE_ID>";
            ov_xml_str = ov_xml_str + "  <MESSAGE_DESC>MANIFEST</MESSAGE_DESC>";
            ov_xml_str = ov_xml_str + "  <VERSION>1.0</VERSION>";
            ov_xml_str = ov_xml_str + "  <OP_MODE>ADD</OP_MODE>";
            ov_xml_str = ov_xml_str + "  <FILE_TIME>" + wl_time + "</FILE_TIME>";
            ov_xml_str = ov_xml_str + "  <SENDER></SENDER>";//发送者 
            ov_xml_str = ov_xml_str + "  <RECEIVER></RECEIVER>";//接收者
            ov_xml_str = ov_xml_str + "  <MANIFEST>";
            ov_xml_str = ov_xml_str + "    <I_E_FLAG>" + wl_i_e_id + "</I_E_FLAG>";
            ov_xml_str = ov_xml_str + "    <I_F_FLAG>" + wl_trade_id + "</I_F_FLAG>";
            ov_xml_str = ov_xml_str + "    <SHIP_NAME_CN>" + wl_c_ship_nam + "</SHIP_NAME_CN>";
            ov_xml_str = ov_xml_str + "    <SHIP_NAME_EN>" + wl_e_ship_nam + "</SHIP_NAME_EN>";
            ov_xml_str = ov_xml_str + "    <VOYAGE_NO>" + wl_voyage + "</VOYAGE_NO>";
            ov_xml_str = ov_xml_str + "    <IDENTITY_NO></IDENTITY_NO>";//船舶识别码
            ov_xml_str = ov_xml_str + "    <IMO_NO>" + wl_custom_no + "</IMO_NO>";
            ov_xml_str = ov_xml_str + "    <I_E_DATE>" + wl_time + "</I_E_DATE>";
            ov_xml_str = ov_xml_str + "    <SHIP_REGISTER></SHIP_REGISTER>";//初始登记号
            ov_xml_str = ov_xml_str + "    <WHARF_CODE></WHARF_CODE>";//码头锚地编码
            ov_xml_str = ov_xml_str + "    <WHARF_NAME></WHARF_NAME>";//码头锚地名称
            ov_xml_str = ov_xml_str + "    <TO_PORT></TO_PORT>";//目的港口或者发航港口
            ov_xml_str = ov_xml_str + "    <BILL_NUM>" + wl_bill_num + "</BILL_NUM>"; 
            foreach (DataRow dr in dt.Rows)
            {

                ov_xml_str = ov_xml_str + "    <BILL>";
                ov_xml_str = ov_xml_str + "      <BILL_SEQ_NO>" +dr["SEQ_NO"].ToString()+"</BILL_SEQ_NO>";
                ov_xml_str = ov_xml_str + "      <BILL_NO>" + dr["BILL_NO"].ToString() + "</BILL_NO>";
                ov_xml_str = ov_xml_str + "      <SHIPPER>" + dr["SHIPPER"].ToString() + "</SHIPPER>";
                ov_xml_str = ov_xml_str + "      <CONSIGNEE>" + dr["CONSIGNEE"].ToString() + "</CONSIGNEE>";
                ov_xml_str = ov_xml_str + "      <LOAD_PORT>" + dr["LOAD_PORT_COD"].ToString() + "</LOAD_PORT>";
                ov_xml_str = ov_xml_str + "      <DISCHARGE_PORT>" + dr["DISC_PORT_COD"].ToString() + "</DISCHARGE_PORT>";
                ov_xml_str = ov_xml_str + "      <GENERAL>1</GENERAL>";
                ov_xml_str = ov_xml_str + "      <REMARK>" + dr["REMARK_TXT"].ToString() + "</REMARK>";
                ov_xml_str = ov_xml_str + "      <TRANSIT>" + dr["TRANS_ID"].ToString() + "</TRANSIT>";
                DataTable gdt = Get_bill_cargo(iv_ship_no, dr["BILL_NO"].ToString());
                foreach (DataRow gdr in gdt.Rows)
                {
                    ov_xml_str = ov_xml_str + "      <CARGO>";
                    ov_xml_str = ov_xml_str + "        <CARGO_SEQ_NO>1</CARGO_SEQ_NO>";
                    ov_xml_str = ov_xml_str + "        <GOODS_NAME>" + gdr["CARGO_NAM"].ToString() + "</GOODS_NAME>";
                    ov_xml_str = ov_xml_str + "        <GOODS_HS></GOODS_HS>";
                    ov_xml_str = ov_xml_str + "        <SYMBOL>" + gdr["CARGO_LABEL"].ToString() + "</SYMBOL>";
                    ov_xml_str = ov_xml_str + "        <GROSS_WT>" + gdr["CARGO_CROSS_WGT"].ToString() + "</GROSS_WT>";
                    ov_xml_str = ov_xml_str + "        <VOLUME>" + gdr["CARGO_VOLUME"].ToString() + "</VOLUME>";
                    ov_xml_str = ov_xml_str + "      </CARGO>";
                }
                DataTable cdt = Get_bill_cntr(iv_ship_no, dr["BILL_NO"].ToString());
                foreach (DataRow cdr in cdt.Rows)
                {

                    ov_xml_str = ov_xml_str + "<CONTAINER>";
                    ov_xml_str = ov_xml_str + "<CONTA_SEQ_NO>" + cdr["SEQ_NO"].ToString() + "</CONTA_SEQ_NO>";
                    ov_xml_str = ov_xml_str + "<CONTA_NO>" + cdr["CNTR"].ToString() + "</CONTA_NO>";
                    ov_xml_str = ov_xml_str + "<ISO_TYPE>" + cdr["CNTR_SIZ_COD"].ToString() + "</ISO_TYPE>";
                    ov_xml_str = ov_xml_str + "<CONTA_STATUS>" + cdr["E_F_ID"].ToString() + "</CONTA_STATUS>";
                    ov_xml_str = ov_xml_str + "<SEAL_NO>" + cdr["CNTR_SEAL_NO"].ToString() + "</SEAL_NO>";   
                    ov_xml_str = ov_xml_str + "   </CONTAINER>";     

                }
                ov_xml_str = ov_xml_str + "   </BILL>";  
            }

           ov_xml_str = ov_xml_str +"   </MANIFEST>";
           ov_xml_str = ov_xml_str + "   </MESSAGE> ";
            strXml = ov_xml_str;
            return strXml;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string v_ta, v_check = "0";

            if (this.dataGridView1.Rows.Count > 0) { this.dataGridView1.Rows.Clear(); }
            else
            {
                List<V_WAILI_SHIP> lst_tmp = BUL.Commone.Get_v_waili_ship();//(s.GUID,s.VESSELE,s.VOYNUMBER);

                if (lst_tmp != null && lst_tmp.Count > 0 && v_check == "0")
                {
                    // lst_cntr.AddRange(lst_tmp);
                    foreach (V_WAILI_SHIP cc in lst_tmp)
                    {
                        this.dataGridView1.Rows.Add(cc.SELECTID,cc.SHIP_COD, cc.SHIP_NAM, cc.SHIP_NO, cc.VOYAGE, cc.BERTH_COD, cc.I_E_ID);
                    }
                    this.dataGridView1.ClearSelection();
                }
                else
                {
                    this.dataGridView1.ClearSelection();
                    return;
                }
            }
            if (this.dataGridView1.Rows.Count != 0)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; )
                {
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.SpringGreen;
                    i += 2;
                }
            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ls_xml_cntr = null, ls_xml_cntr_typ = null, ls_xml_ef = null, ls_xml_seal = null, ls_xml_equipment = null;
            string ls_xml_bill_no = null, 
                   ls_xml_consignment = null,
                   ls_CUSTOMID = null,
                   ls_SHIP_COD = null, ls_VOYAGE = null,
                   ls_MESSAGEID = null, ls_SENDID = null,ls_rec_nam = null;
            string ls_xm_body = null,ls_check="0";
            string ls_server, ls_user, ls_pass, ls_path,ls_con;
            int li_count = 0, li_count_bill = 0; 
            myIni = new IniFile(Application.StartupPath + "\\Run.ini");
            ls_server = myIni.ReadString("DataBase", "Server", "tserver3");
            ls_user = myIni.ReadString("DataBase", "User", "dd_plan");
            ls_pass = myIni.ReadString("DataBase", "Pass", "ok");
            ls_path= myIni.ReadString("DataBase", "Path", "D:\\");
            Directory.CreateDirectory(@ls_path);
            System.Data.OracleClient.OracleConnection Con1 = new System.Data.OracleClient.OracleConnection(); 
            System.Data.OracleClient.OracleDataAdapter DA1 = new System.Data.OracleClient.OracleDataAdapter();
            System.Data.OracleClient.OracleCommand oracleSelectCommand1 = new System.Data.OracleClient.OracleCommand();
            ls_con = "data source=" +ls_server + ";user id=" + ls_user + ";password=" + ls_pass;
            if (Con1.State == ConnectionState.Open)
            {
                Con1.Close();
            }
            try
            {
                if (Con1.State != ConnectionState.Open)
                {
                    Con1.ConnectionString = ls_con;
                    Con1.Open();
                }
            }
            catch (Exception ex)
            { 
                // MessageBox.Show(ex.Message, "数据库连接失败");
            }
            ///////正常报文生成
            oracleSelectCommand1.Connection = Con1;
            DA1.SelectCommand = oracleSelectCommand1; 
            System.Data.OracleClient.OracleTransaction myTran; 
            myTran = Con1.BeginTransaction();
            oracleSelectCommand1 = Con1.CreateCommand();
            oracleSelectCommand1.Transaction = myTran;  
            oracleSelectCommand1.CommandType = CommandType.StoredProcedure;
            li_count = dataGridView1.RowCount;
                try
                { 
                     for (int i = 0; i < li_count; i++)
                     {
                         if (dataGridView1.Rows[i].Cells["SELECTID"].Value.ToString() == "1")
                         {
                            ls_SHIP_COD=dataGridView1.Rows[i].Cells["SHIP_NO"].Value.ToString();
                            oracleSelectCommand1.Parameters.Clear();
                            oracleSelectCommand1.CommandText = "P_GEN_BILL_XML";
                            System.Data.OracleClient.OracleParameter p;
                            p = new OracleParameter("IV_SHIP_NO", OracleType.VarChar, 2000);
                            oracleSelectCommand1.Parameters.Add(p);
                            p.Direction = ParameterDirection.Input;
                            p.Value = ls_SHIP_COD;   
                            p = new OracleParameter("OV_XML_STR1", OracleType.Clob);//Cursor);
                            oracleSelectCommand1.Parameters.Add(p);
                            p.Direction = ParameterDirection.Output;//设置为Output  
                            if (oracleSelectCommand1.ExecuteNonQuery() > 0)
                            {
                                OracleLob ob = (OracleLob)p.Value;
                                byte[] buffer = new byte[ob.Length];
                                ob.Read(buffer, 0, (int)ob.Length);
                                Encoding coder = Encoding.Unicode;
                                string strXml = coder.GetString(buffer);
                                if (strXml == "*")
                                {
                                    MessageBox.Show("报文格式错误！");
                                }
                                XmlDocument doc = new XmlDocument();
                                doc.LoadXml(strXml);
                                ls_MESSAGEID = dataGridView1.Rows[i].Cells["SHIP_NAM"].Value.ToString();
                                ls_SENDID = dataGridView1.Rows[i].Cells["VOYAGE"].Value.ToString();
                                doc.Save(ls_path + "\\" + "CN_" + ls_MESSAGEID + "_" + ls_SENDID + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xml");
                                ls_SHIP_COD = "";
                            }
                             
                        }
                          
                    }

                     MessageBox.Show("报文生成完毕");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    if (myTran != null)
                    {
                        myTran.Rollback();
                         
                    }
                     
                }
                finally
                {
                }
        }
           private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
          
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              
        
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value == "0")
            { dataGridView1.CurrentRow.Cells[0].Value = "1"; }
            else
            {
                dataGridView1.CurrentRow.Cells[0].Value = "0";
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string ls_xml_cntr = null, ls_xml_cntr_typ = null, ls_xml_ef = null, ls_xml_seal = null, ls_xml_equipment = null;
            string ls_xml_bill_no = null,
                   ls_xml_consignment = null,
                   ls_CUSTOMID = null,
                   ls_SHIP_COD = null, ls_VOYAGE = null,
                   ls_MESSAGEID = null, ls_SENDID = null, ls_rec_nam = null;
            string ls_xm_body = null, ls_check = "0";
            string ls_server, ls_user, ls_pass, ls_path, ls_con;
            int li_count = 0, li_count_bill = 0;
            myIni = new IniFile(Application.StartupPath + "\\Run.ini");
            ls_server = myIni.ReadString("DataBase", "Server", "tserver3");
            ls_user = myIni.ReadString("DataBase", "User", "dd_plan");
            ls_pass = myIni.ReadString("DataBase", "Pass", "ok");
            ls_path = myIni.ReadString("DataBase", "Path", "D:\\");
            Directory.CreateDirectory(@ls_path);
            System.Data.OracleClient.OracleConnection Con1 = new System.Data.OracleClient.OracleConnection();
            System.Data.OracleClient.OracleDataAdapter DA1 = new System.Data.OracleClient.OracleDataAdapter();
            System.Data.OracleClient.OracleCommand oracleSelectCommand1 = new System.Data.OracleClient.OracleCommand();
            ls_con = "data source=" + ls_server + ";user id=" + ls_user + ";password=" + ls_pass;
            if (Con1.State == ConnectionState.Open)
            {
                Con1.Close();
            }
            try
            {
                if (Con1.State != ConnectionState.Open)
                {
                    Con1.ConnectionString = ls_con;
                    Con1.Open();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message, "数据库连接失败");
            }
            ///////正常报文生成
            oracleSelectCommand1.Connection = Con1;
            DA1.SelectCommand = oracleSelectCommand1;
            System.Data.OracleClient.OracleTransaction myTran;
            myTran = Con1.BeginTransaction();
            oracleSelectCommand1 = Con1.CreateCommand();
            oracleSelectCommand1.Transaction = myTran;
            oracleSelectCommand1.CommandType = CommandType.StoredProcedure;
            li_count = dataGridView1.RowCount;
            try
            {
                for (int i = 0; i < li_count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["SELECTID"].Value.ToString() == "1")
                    {
                        ls_SHIP_COD = dataGridView1.Rows[i].Cells["SHIP_NO"].Value.ToString();
                        strXml = gen_xml(ls_SHIP_COD);
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(strXml);
                        ls_MESSAGEID = dataGridView1.Rows[i].Cells["SHIP_NAM"].Value.ToString();
                        ls_SENDID = dataGridView1.Rows[i].Cells["VOYAGE"].Value.ToString();
                        doc.Save(ls_path + "\\" + "CN_" + ls_MESSAGEID + "_" + ls_SENDID + "_" +
                                 DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xml");
                        ls_SHIP_COD = "";

                        MessageBox.Show("报文生成完毕");
                    }
                }
            }
            catch
                (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                if (myTran != null)
                {
                    myTran.Rollback();

                }

            }
            finally
            {
            }
        }
    }
}
