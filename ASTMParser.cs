/*
 * Valentin Heinitz, 2014-10-30 01:54
 * http://heinitz-it.de
 * ASTM-1394 parser. Parses contents ASTM messages and created object tree.
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace ASTMParser
{
    abstract public class ASTM_Record
    {

        public abstract bool parseData(String recordData);
        public abstract bool addComment(String recordData);
        public abstract bool addManufacturerInfo(String recordData);
        public abstract String fieldName(int idx);
        public abstract String fieldValue(int idx);
        public abstract int fieldsCount();
        public abstract List<ASTM_Record> comments();
        public abstract List<ASTM_Record> manufacturerInfo();
    }

    public class ASTM_Comment : ASTM_Record
    {
        String f_type;// "Record Type ID"
        String f_seq;// "Sequence Number"
        public String f_source;// "Comment Source"
        public String f_data;// "Comment Text"
        public String f_ctype;// "Comment Type"

        public List<ASTM_Manufacturer> manufacturerRecords = new List<ASTM_Manufacturer>();

        public override List<ASTM_Record> comments() { return null; }
        public override List<ASTM_Record> manufacturerInfo() { return null; }

        List<String> fieldNames = new List<String>(new String[] { 
                    "Record Type ID"
                    , "Sequence Number"
                    , "Comment Source"
                    , "Comment Text"
                    , "Comment Type"
            });

        public override int fieldsCount()
        {
            return fieldNames.Count();
        }

        public override String fieldName(int idx)
        {
            idx--;
            if (idx < 0 || idx >= fieldNames.Count())
                return null;
            return fieldNames.ElementAt(idx);
        }

        public override String fieldValue(int idx)
        {
            if (idx < 1 || idx > fieldNames.Count())
                return null;
            switch (idx)
            {
                case (1): return f_type;
                case (2): return f_seq;
                case (3): return f_source;
                case (4): return f_data;
                case (5): return f_ctype;
                default: return null;
            }
        }

        public override bool addComment(String recordData)
        {
            //TODO Log error
            return false;
        }

        public override bool addManufacturerInfo(String recordData)
        {
            //TODO Log error
            return false;
        }

        public override bool parseData(String recordData)
        {
            var recordValues = Regex.Split(recordData, "[|]");
            int idx = 1;
            foreach (var v in recordValues)
            {
                switch (idx)
                {
                    case (1): f_type = v; break;
                    case (2): f_seq = v; break;
                    case (3): f_source = v; break;
                    case (4): f_data = v; break;
                    case (5): f_ctype = v; break;
                    default: return false;
                }
                idx++;
            }
            return true;
        }
    }

    public class ASTM_Manufacturer : ASTM_Record
    {
        String f_type;// "Record Type ID"
        String f_seq;// "Sequence Number"
        public String f_mf1;// "Manufacturer Field 1"
        public String f_mf2;// "Manufacturer Field 2"
        public String f_mf3;// "Manufacturer Field 3"
        public String f_mf4;// "Manufacturer Field 4"
        public String f_mf5;// "Manufacturer Field 5"

        public List<ASTM_Comment> commentRecords = new List<ASTM_Comment>();

        public override List<ASTM_Record> comments() { return commentRecords.ToList<ASTM_Record>(); }
        public override List<ASTM_Record> manufacturerInfo() { return null; }

        List<String> fieldNames = new List<String>(new String[] { 
                    "Record Type ID"
                    , "Sequence Number"
                    , "Manufacturer Field 1"
                    , "Manufacturer Field 2"
                    , "Manufacturer Field 3"
                    , "Manufacturer Field 4"
                    , "Manufacturer Field 5"
            });

        public override int fieldsCount()
        {
            return fieldNames.Count();
        }

        public override String fieldName(int idx)
        {
            idx--;
            if (idx < 0 || idx >= fieldNames.Count())
                return null;
            return fieldNames.ElementAt(idx);
        }

        public override String fieldValue(int idx)
        {
            if (idx < 1 || idx > fieldNames.Count())
                return null;
            switch (idx)
            {
                case (1): return f_type;
                case (2): return f_seq;
                case (3): return f_mf1;
                case (4): return f_mf2;
                case (5): return f_mf3;
                case (6): return f_mf4;
                case (7): return f_mf5;
                default: return null;
            }
        }

        public override bool addComment(String recordData)
        {
            //TODO Log error
            return false;
        }

        public override bool addManufacturerInfo(String recordData)
        {
            //TODO Log error
            return false;
        }

        public override bool parseData(String recordData)
        {
            var recordValues = Regex.Split(recordData, "[|]");
            int idx = 1;
            foreach (var v in recordValues)
            {
                switch (idx)
                {
                    case (1): f_type = v; break;
                    case (2): f_seq = v; break;
                    case (3): f_mf1 = v; break;
                    case (4): f_mf2 = v; break;
                    case (5): f_mf3 = v; break;
                    case (6): f_mf4 = v; break;
                    case (7): f_mf5 = v; break;
                    default: return false;
                }
                idx++;
            }
            return true;
        }
    }

    public class ASTM_Scientific : ASTM_Record
    {


        String f_type;// "Record Type ID"
        String f_seq;// "Sequence Number"
        public String f_anmeth;// "Analytical Method"
        public String f_instr;// "Instrumentation"
        public String f_reagents;// "Reagents"
        public String f_unitofmeas;// "Units of Measure"
        public String f_qc;// "Quality Control"
        public String f_spcmdescr;// "Specimen Descriptor"
        public String f_resrvd;// "Reserved Field"
        public String f_container;// "Container"
        public String f_spcmid;// "Specimen ID"
        public String f_analyte;// "Analyte"
        public String f_result;// "Result"
        public String f_resunts;// "Result Units"
        public String f_collctdt;// "Collection Date and Time"
        public String f_resdt;// "Result Date and Time"
        public String f_anlprocstp;// "Analytical Preprocessing Steps"
        public String f_patdiagn;// "Patient Diagnosis"
        public String f_patbd;// "Patient Birthdate"
        public String f_patsex;// "Patient Sex"
        public String f_patrace;// "Patient Race"



        public List<ASTM_Manufacturer> manufacturerRecords = new List<ASTM_Manufacturer>();
        public List<ASTM_Comment> commentRecords = new List<ASTM_Comment>();

        public override List<ASTM_Record> comments() { return commentRecords.ToList<ASTM_Record>(); }
        public override List<ASTM_Record> manufacturerInfo() { return manufacturerRecords.ToList<ASTM_Record>(); }

        List<String> fieldNames = new List<String>(new String[] { 
                    "Record Type ID"
                    , "Sequence Number"
                    , "Analytical Method"
                    , "Instrumentation"
                    , "Reagents"
                    , "Units of Measure"
                    , "Quality Control"
                    , "Specimen Descriptor"
                    , "Reserved Field"
                    , "Container"
                    , "Specimen ID"
                    , "Analyte"
                    , "Result"
                    , "Result Units"
                    , "Collection Date and Time"
                    , "Result Date and Time"
                    , "Analytical Preprocessing Steps"
                    , "Patient Diagnosis"
                    , "Patient Birthdate"
                    , "Patient Sex"
                    , "Patient Race"     
            });

        public override int fieldsCount()
        {
            return fieldNames.Count();
        }

        public override String fieldName(int idx)
        {
            idx--;
            if (idx < 0 || idx >= fieldNames.Count())
                return null;
            return fieldNames.ElementAt(idx);
        }

        public override String fieldValue(int idx)
        {
            if (idx < 1 || idx > fieldNames.Count())
                return null;
            switch (idx)
            {
                case (1): return f_type;
                case (2): return f_seq;
                case (3): return f_anmeth;
                case (4): return f_instr;
                case (5): return f_reagents;
                case (6): return f_unitofmeas;
                case (7): return f_qc;
                case (8): return f_spcmdescr;
                case (9): return f_resrvd;
                case (10): return f_container;
                case (11): return f_spcmid;
                case (12): return f_analyte;
                case (13): return f_result;
                case (14): return f_resunts;
                case (15): return f_collctdt;
                case (16): return f_resdt;
                case (17): return f_anlprocstp;
                case (18): return f_patdiagn;
                case (19): return f_patbd;
                case (20): return f_patsex;
                case (21): return f_patrace;
                default: return null;
            }
        }

        public override bool addComment(String recordData)
        {
            commentRecords.Add(new ASTM_Comment());
            return commentRecords.Last().parseData(recordData);
        }

        public override bool addManufacturerInfo(String recordData)
        {
            manufacturerRecords.Add(new ASTM_Manufacturer());
            return manufacturerRecords.Last().parseData(recordData);
        }

        public override bool parseData(String recordData)
        {
            var recordValues = Regex.Split(recordData, "[|]");
            int idx = 1;
            foreach (var v in recordValues)
            {
                switch (idx)
                {
                    case (1): f_type = v; break;
                    case (2): f_seq = v; break;
                    case (3): f_anmeth = v; break;
                    case (4): f_instr = v; break;
                    case (5): f_reagents = v; break;
                    case (6): f_unitofmeas = v; break;
                    case (7): f_qc = v; break;
                    case (8): f_spcmdescr = v; break;
                    case (9): f_resrvd = v; break;
                    case (10): f_container = v; break;
                    case (11): f_spcmid = v; break;
                    case (12): f_analyte = v; break;
                    case (13): f_result = v; break;
                    case (14): f_resunts = v; break;
                    case (15): f_collctdt = v; break;
                    case (16): f_resdt = v; break;
                    case (17): f_anlprocstp = v; break;
                    case (18): f_patdiagn = v; break;
                    case (19): f_patbd = v; break;
                    case (20): f_patsex = v; break;
                    case (21): f_patrace = v; break;
                    default: return false;
                }
                idx++;
            }
            return true;
        }
    }

    public class ASTM_Order : ASTM_Record
    {

        String f_type;// "Record Type ID"
        String f_seq;// "Sequence Number"
        public String f_sample_id;// "Specimen ID"
        public String f_instrument;// "Instrument Specimen ID"
        public String f_test;// "Universal Test ID"
        public String f_priority;// "Priority"
        public String f_created_at;// "Requested/Ordered Date/Time"
        public String f_sampled_at;// "Specimen Collection Date/Time"
        public String f_collected_at;// "Collection End Time"
        public String f_volume;// "Collection Volume"
        public String f_collector;// "Collector ID"
        public String f_action_code;// "Action Code"
        public String f_danger_code;// "Danger Code"
        public String f_clinical_info;// "Relevant Information"
        public String f_delivered_at;// "Date/Time Specimen Received"
        public String f_biomaterial;// "Specimen Descriptor"
        public String f_physician;// "Ordering Physician"
        public String f_physician_phone;// "Physician's Telephone Number"
        public String f_user_field_1;// "User Field No. 1"
        public String f_user_field_2;// "User Field No. 2"
        public String f_laboratory_field_1;// "Laboratory Field No. 1"
        public String f_laboratory_field_2;// "Laboratory Field No. 2"
        public String f_modified_at;// "Date/Time Reported"
        public String f_instrument_charge;// "Instrument Charge"
        public String f_instrument_section;// "Instrument Section ID"
        public String f_report_type;// "Report Type"

        public List<ASTM_Result> resultRecords = new List<ASTM_Result>();
        public List<ASTM_Manufacturer> manufacturerRecords = new List<ASTM_Manufacturer>();
        public List<ASTM_Comment> commentRecords = new List<ASTM_Comment>();

        public override List<ASTM_Record> comments() { return commentRecords.ToList<ASTM_Record>(); }
        public override List<ASTM_Record> manufacturerInfo() { return manufacturerRecords.ToList<ASTM_Record>(); }

        List<String> fieldNames = new List<String>(new String[] { 
                    "Record Type ID"
                    , "Sequence Number"
                    , "Specimen ID"
                    , "Instrument Specimen ID"
                    , "Universal Test ID"
                    , "Priority"
                    , "Requested/Ordered Date/Time"
                    , "Specimen Collection Date/Time"
                    , "Collection End Time"
                    , "Collection Volume"
                    , "Collector ID"
                    , "Action Code"
                    , "Danger Code"
                    , "Relevant Information"
                    , "Date/Time Specimen Received"
                    , "Specimen Descriptor"
                    , "Ordering Physician"
                    , "Physician's Telephone Number"
                    , "User Field No. 1"
                    , "User Field No. 2"
                    , "Laboratory Field No. 1"
                    , "Laboratory Field No. 2"
                    , "Date/Time Reported"
                    , "Instrument Charge"
                    , "Instrument Section ID"
                    , "Report Type"
            });

        public override int fieldsCount()
        {
            return fieldNames.Count();
        }

        public override String fieldName(int idx)
        {
            idx--;
            if (idx < 0 || idx >= fieldNames.Count())
                return null;
            return fieldNames.ElementAt(idx);
        }

        public override String fieldValue(int idx)
        {
            if (idx < 1 || idx > fieldNames.Count())
                return null;
            switch (idx)
            {
                case (1): return f_type;
                case (2): return f_seq;
                case (3): return f_sample_id;
                case (4): return f_instrument;
                case (5): return f_test;
                case (6): return f_priority;
                case (7): return f_created_at;
                case (8): return f_sampled_at;
                case (9): return f_collected_at;
                case (10): return f_volume;
                case (11): return f_collector;
                case (12): return f_action_code;
                case (13): return f_danger_code;
                case (14): return f_clinical_info;
                case (15): return f_delivered_at;
                case (16): return f_biomaterial;
                case (17): return f_physician;
                case (18): return f_physician_phone;
                case (19): return f_user_field_1;
                case (20): return f_user_field_2;
                case (21): return f_laboratory_field_1;
                case (22): return f_laboratory_field_2;
                case (23): return f_modified_at;
                case (24): return f_instrument_charge;
                case (25): return f_instrument_section;
                case (26): return f_report_type;
                default: return null;
            }
        }

        public override bool addComment(String recordData)
        {
            commentRecords.Add(new ASTM_Comment());
            return commentRecords.Last().parseData(recordData);
        }

        public override bool addManufacturerInfo(String recordData)
        {
            manufacturerRecords.Add(new ASTM_Manufacturer());
            return manufacturerRecords.Last().parseData(recordData);
        }

        public override bool parseData(String recordData)
        {
            var recordValues = Regex.Split(recordData, "[|]");
            int idx = 1;
            foreach (var v in recordValues)
            {
                switch (idx)
                {
                    case (1): f_type = v; break;
                    case (2): f_seq = v; break;
                    case (3): f_sample_id = v; break;
                    case (4): f_instrument = v; break;
                    case (5): f_test = v; break;
                    case (6): f_priority = v; break;
                    case (7): f_created_at = v; break;
                    case (8): f_sampled_at = v; break;
                    case (9): f_collected_at = v; break;
                    case (10): f_volume = v; break;
                    case (11): f_collector = v; break;
                    case (12): f_action_code = v; break;
                    case (13): f_danger_code = v; break;
                    case (14): f_clinical_info = v; break;
                    case (15): f_delivered_at = v; break;
                    case (16): f_biomaterial = v; break;
                    case (17): f_physician = v; break;
                    case (18): f_physician_phone = v; break;
                    case (19): f_user_field_1 = v; break;
                    case (20): f_user_field_2 = v; break;
                    case (21): f_laboratory_field_1 = v; break;
                    case (22): f_laboratory_field_2 = v; break;
                    case (23): f_modified_at = v; break;
                    case (24): f_instrument_charge = v; break;
                    case (25): f_instrument_section = v; break;
                    case (26): f_report_type = v; break;
                    default: return false;
                }
                idx++;
            }
            return true;
        }
    }

    public class ASTM_Result : ASTM_Record
    {
        String f_type;// "Record Type ID"
        String f_seq;// "Sequence Number"
        public String f_test;// "Universal Test ID"
        public String f_value;// "Data or Measurement Value"
        public String f_units;// "Units"
        public String f_references;// "Reference Ranges"
        public String f_abnormal_flag;// "Result Abnormal Flags"
        public String f_abnormality_nature;// "Nature of Abnormal Testing"
        public String f_status;// "Results Status"
        public String f_norms_changed_at;// "Date of Changein Instrument"
        public String f_operator;// "Operator Identification"
        public String f_started_at;// "Date/Time Test Started"
        public String f_completed_at;// "Date/Time Test Complete"
        public String f_instrument;// "Instrument Identification"

        public List<ASTM_Manufacturer> manufacturerRecords = new List<ASTM_Manufacturer>();
        public List<ASTM_Comment> commentRecords = new List<ASTM_Comment>();

        public override List<ASTM_Record> comments() { return commentRecords.ToList<ASTM_Record>(); }
        public override List<ASTM_Record> manufacturerInfo() { return manufacturerRecords.ToList<ASTM_Record>(); }

        List<String> fieldNames = new List<String>(new String[] { 
                    "Record Type ID"
                    , "Sequence Number"
                    , "Universal Test ID"
                    , "Data or Measurement Value"
                    , "Units"
                    , "Reference Ranges"
                    , "Result Abnormal Flags"
                    , "Nature of Abnormal Testing"
                    , "Results Status"
                    , "Date of Changein Instrument"
                    , "Operator Identification"
                    , "Date/Time Test Started"
                    , "Date/Time Test Complete"
                    , "Instrument Identification"
            });

        public override int fieldsCount()
        {
            return fieldNames.Count();
        }

        public override String fieldName(int idx)
        {
            idx--;
            if (idx < 0 || idx >= fieldNames.Count())
                return null;
            return fieldNames.ElementAt(idx);
        }

        public override String fieldValue(int idx)
        {
            if (idx < 1 || idx > fieldNames.Count())
                return null;
            switch (idx)
            {
                case (1): return f_type;
                case (2): return f_seq;
                case (3): return f_test;
                case (4): return f_value;
                case (5): return f_units;
                case (6): return f_references;
                case (7): return f_abnormal_flag;
                case (8): return f_abnormality_nature;
                case (9): return f_status;
                case (10): return f_norms_changed_at;
                case (11): return f_operator;
                case (12): return f_started_at;
                case (13): return f_completed_at;
                case (14): return f_instrument;
                default: return null;
            }



        }

        public override bool addComment(String recordData)
        {
            commentRecords.Add(new ASTM_Comment());
            return commentRecords.Last().parseData(recordData);
        }

        public override bool addManufacturerInfo(String recordData)
        {
            manufacturerRecords.Add(new ASTM_Manufacturer());
            return manufacturerRecords.Last().parseData(recordData);
        }

        public override bool parseData(String recordData)
        {
            var recordValues = Regex.Split(recordData, "[|]");
            int idx = 1;
            foreach (var v in recordValues)
            {
                switch (idx)
                {
                    case (1): f_type = v; break;
                    case (2): f_seq = v; break;
                    case (3): f_test = v; break;
                    case (4): f_value = v; break;
                    case (5): f_units = v; break;
                    case (6): f_references = v; break;
                    case (7): f_abnormal_flag = v; break;
                    case (8): f_abnormality_nature = v; break;
                    case (9): f_status = v; break;
                    case (10): f_norms_changed_at = v; break;
                    case (11): f_operator = v; break;
                    case (12): f_started_at = v; break;
                    case (13): f_completed_at = v; break;
                    case (14): f_instrument = v; break;
                    default: return false;
                }
                idx++;
            }
            return true;
        }
    }


    public class ASTM_Patient : ASTM_Record
    {
        String f_type;// "Record Type ID"
        String f_seq;// "Sequence Number"
        public String f_practice_id;// "Practice Assigned Patient ID"
        public String f_laboratory_id;// "Laboratory Assigned Patient ID"
        public String f_id;// "Patient ID"
        public String f_name;// "Patient Name"
        public String f_maiden_name;// "Mother?s Maiden Name"
        public String f_birthdate;// "Birthdate"
        public String f_sex;// "Patient Sex"
        public String f_race;// "Patient Race-, Ethnic Origin"
        public String f_address;// "Patient Address"
        public String f_reserved;// "Reserved Field"
        public String f_phone;// "Patient Telephone Number"
        public String f_physician_id;// "Attending Physician ID"
        public String f_special_1;// "Special Field No. 1"
        public String f_special_2;// "Special Field No. 2"
        public String f_height;// "Patient Height"
        public String f_weight;// "Patient Weight"
        public String f_diagnosis;// "Patient's Known Diagnosis"
        public String f_medication;// "Patient?s Active Medication"
        public String f_diet;// "Patient's Diet"
        public String f_practice_field_1;// "Practice Field No. 1"
        public String f_practice_field_2;// "Practice Field No. 2"
        public String f_admission_date;// "Admission/Discharge Dates"
        public String f_admission_status;// "Admission Status"
        public String f_location;// "Location"

        public List<ASTM_Manufacturer> manufacturerRecords = new List<ASTM_Manufacturer>();
        public List<ASTM_Order> orderRecords = new List<ASTM_Order>();
        public List<ASTM_Comment> commentRecords = new List<ASTM_Comment>();

        public override List<ASTM_Record> comments() { return commentRecords.ToList<ASTM_Record>(); }
        public override List<ASTM_Record> manufacturerInfo() { return manufacturerRecords.ToList<ASTM_Record>(); }

        List<String> fieldNames = new List<String>(new String[] { 
                    "Record Type ID"
                    , "Sequence Number"
                    , "Practice Assigned Patient ID"
                    , "Laboratory Assigned Patient ID"
                    , "Patient ID"
                    , "Patient Name"
                    , "Mother?s Maiden Name"
                    , "Birthdate"
                    , "Patient Sex"
                    , "Patient Race-, Ethnic Origin"
                    , "Patient Address"
                    , "Reserved Field"
                    , "Patient Telephone Number"
                    , "Attending Physician ID"
                    , "Special Field No. 1"
                    , "Special Field No. 2"
                    , "Patient Height"
                    , "Patient Weight"
                    , "Patient's Known Diagnosis"
                    , "Patient?s Active Medication"
                    , "Patient's Diet"
                    , "Practice Field No. 1"
                    , "Practice Field No. 2"
                    , "Admission/Discharge Dates"
                    , "Admission Status"
                    , "Location"


            });

        public override int fieldsCount()
        {
            return fieldNames.Count();
        }

        public override String fieldName(int idx)
        {
            idx--;
            if (idx < 0 || idx >= fieldNames.Count())
                return null;
            return fieldNames.ElementAt(idx);
        }

        public override String fieldValue(int idx)
        {
            if (idx < 1 || idx > fieldNames.Count())
                return null;
            switch (idx)
            {
                case (1): return f_type;
                case (2): return f_seq;
                case (3): return f_practice_id;
                case (4): return f_laboratory_id;
                case (5): return f_id;
                case (6): return f_name;
                case (7): return f_maiden_name;
                case (8): return f_birthdate;
                case (9): return f_sex;
                case (10): return f_race;
                case (11): return f_address;
                case (12): return f_reserved;
                case (13): return f_phone;
                case (14): return f_physician_id;
                case (15): return f_special_1;
                case (16): return f_special_2;
                case (17): return f_height;
                case (18): return f_weight;
                case (19): return f_diagnosis;
                case (20): return f_medication;
                case (21): return f_diet;
                case (22): return f_practice_field_1;
                case (23): return f_practice_field_2;
                case (24): return f_admission_date;
                case (25): return f_admission_status;
                case (26): return f_location;
                default: return null;
            }

        }

        public override bool addComment(String recordData)
        {
            commentRecords.Add(new ASTM_Comment());
            return commentRecords.Last().parseData(recordData);
        }

        public override bool addManufacturerInfo(String recordData)
        {
            manufacturerRecords.Add(new ASTM_Manufacturer());
            return manufacturerRecords.Last().parseData(recordData);
        }

        public override bool parseData(String recordData)
        {
            var recordValues = Regex.Split(recordData, "[|]");
            int idx = 1;
            foreach (var v in recordValues)
            {
                switch (idx)
                {
                    case (1): f_type = v; break;
                    case (2): f_seq = v; break;
                    case (3): f_practice_id = v; break;
                    case (4): f_laboratory_id = v; break;
                    case (5): f_id = v; break;
                    case (6): f_name = v; break;
                    case (7): f_maiden_name = v; break;
                    case (8): f_birthdate = v; break;
                    case (9): f_sex = v; break;
                    case (10): f_race = v; break;
                    case (11): f_address = v; break;
                    case (12): f_reserved = v; break;
                    case (13): f_phone = v; break;
                    case (14): f_physician_id = v; break;
                    case (15): f_special_1 = v; break;
                    case (16): f_special_2 = v; break;
                    case (17): f_height = v; break;
                    case (18): f_weight = v; break;
                    case (19): f_diagnosis = v; break;
                    case (20): f_medication = v; break;
                    case (21): f_diet = v; break;
                    case (22): f_practice_field_1 = v; break;
                    case (23): f_practice_field_2 = v; break;
                    case (24): f_admission_date = v; break;
                    case (25): f_admission_status = v; break;
                    case (26): f_location = v; break;
                    default: return false;
                }
                idx++;
            }
            return true;
        }
    }

    public class ASTM_Request : ASTM_Record
    {
        String f_type;// "Record Type ID"
        String f_seq;// "Sequence Number"
        public String f_srangeid;// "Starting Range ID Number"
        public String f_erangeid;// "Ending Range ID Number"
        public String f_utestid;// "Universal Test ID"
        public String f_noreqtmlim;// "Nature of Request Time Limits"
        public String f_begreqresdt;// "Beginning Request Results Date and Time"
        public String f_endreqresdt;// "Ending Request Results Date and Time"
        public String f_reqphysname;// "Requesting Physician Name"
        public String f_reqphystel;// "Requesting Physician Telephone Number"
        public String f_userfld1;// "User Field No. 1"
        public String f_userfld2;// "User Field No. 2"
        public String f_statcodes;// "Request Information Status Codes"

        public List<ASTM_Manufacturer> manufacturerRecords = new List<ASTM_Manufacturer>();
        public List<ASTM_Comment> commentRecords = new List<ASTM_Comment>();

        public override List<ASTM_Record> comments() { return commentRecords.ToList<ASTM_Record>(); }
        public override List<ASTM_Record> manufacturerInfo() { return manufacturerRecords.ToList<ASTM_Record>(); }

        List<String> fieldNames = new List<String>(new String[] { 
                    "Record Type ID"
                    , "Sequence Number"
                    , "Starting Range ID Number"
                    , "Ending Range ID Number"
                    , "Universal Test ID"
                    , "Nature of Request Time Limits"
                    , "Beginning Request Results Date and Time"
                    , "Ending Request Results Date and Time"
                    , "Requesting Physician Name"
                    , "Requesting Physician Telephone Number"
                    , "User Field No. 1"
                    , "User Field No. 2"
                    , "Request Information Status Codes"
            });

        public override int fieldsCount()
        {
            return fieldNames.Count();
        }

        public override String fieldName(int idx)
        {
            idx--;
            if (idx < 0 || idx >= fieldNames.Count())
                return null;
            return fieldNames.ElementAt(idx);
        }

        public override String fieldValue(int idx)
        {

            if (idx < 1 || idx > fieldNames.Count())
                return null;
            switch (idx)
            {
                case (1): return f_type;
                case (2): return f_seq;
                case (3): return f_srangeid;
                case (4): return f_erangeid;
                case (5): return f_utestid;
                case (6): return f_noreqtmlim;
                case (7): return f_begreqresdt;
                case (8): return f_endreqresdt;
                case (9): return f_reqphysname;
                case (10): return f_reqphystel;
                case (11): return f_userfld1;
                case (12): return f_userfld2;
                case (13): return f_statcodes;
                default: return null;
            }




        }

        public override bool addComment(String recordData)
        {
            commentRecords.Add(new ASTM_Comment());
            return commentRecords.Last().parseData(recordData);
        }

        public override bool addManufacturerInfo(String recordData)
        {
            manufacturerRecords.Add(new ASTM_Manufacturer());
            return manufacturerRecords.Last().parseData(recordData);
        }

        public override bool parseData(String recordData)
        {
            var recordValues = Regex.Split(recordData, "[|]");
            int idx = 1;
            foreach (var v in recordValues)
            {
                switch (idx)
                {
                    case (1): f_type = v; break;
                    case (2): f_seq = v; break;
                    case (3): f_srangeid = v; break;
                    case (4): f_erangeid = v; break;
                    case (5): f_utestid = v; break;
                    case (6): f_noreqtmlim = v; break;
                    case (7): f_begreqresdt = v; break;
                    case (8): f_endreqresdt = v; break;
                    case (9): f_reqphysname = v; break;
                    case (10): f_reqphystel = v; break;
                    case (11): f_userfld1 = v; break;
                    case (12): f_userfld2 = v; break;
                    case (13): f_statcodes = v; break;
                    default: return false;
                }
                idx++;
            }
            return true;
        }

    }


    public class ASTM_Message : ASTM_Record
    {
        String f_type;// "Record Type ID"
        String f_delimeter;// "Delimiter Definition"
        public String f_message_id;// "Message Control ID"
        public String f_password;// "Access Password"
        public String f_sender;// "Sender Name or ID"
        public String f_address;// "Sender Street Address"
        public String f_reserved;// "Reserved Field"
        public String f_phone;// "Sender Telephone Number"
        public String f_caps;// "Characteristics of Sender"
        public String f_receiver;// "Receiver ID"
        public String f_comments;// "Comments"
        public String f_processing_id;// "Processing ID"
        public String f_version;// "Version Number"
        public String f_timestamp;// "Date/Timeof Message"

        public List<ASTM_Manufacturer> manufacturerRecords = new List<ASTM_Manufacturer>();
        public List<ASTM_Scientific> scientificRecords = new List<ASTM_Scientific>();
        public List<ASTM_Patient> patientRecords = new List<ASTM_Patient>();
        public List<ASTM_Comment> commentRecords = new List<ASTM_Comment>();
        public List<ASTM_Request> requestRecords = new List<ASTM_Request>();

        public override List<ASTM_Record> comments() { return commentRecords.ToList<ASTM_Record>(); }
        public override List<ASTM_Record> manufacturerInfo() { return manufacturerRecords.ToList<ASTM_Record>(); }

        List<String> fieldNames = new List<String>(new String[] { 
                    "Record Type ID"
                    , "Delimiter Definition"
                    , "Message Control ID"
                    , "Access Password"
                    , "Sender Name or ID"
                    , "Sender Street Address"
                    , "Reserved Field"
                    , "Sender Telephone Number"
                    , "Characteristics of Sender"
                    , "Receiver ID"
                    , "Comments"
                    , "Processing ID"
                    , "Version Number"
                    , "Date/Timeof Message"
            });

        public override int fieldsCount()
        {
            return fieldNames.Count();
        }

        public override String fieldName(int idx)
        {
            idx--;
            if (idx < 0 || idx >= fieldNames.Count())
                return null;
            return fieldNames.ElementAt(idx);
        }

        public override String fieldValue(int idx)
        {
            if (idx < 1 || idx > fieldNames.Count())
                return null;
            switch (idx)
            {
                case (1): return f_type;
                case (2): return f_delimeter;
                case (3): return f_message_id;
                case (4): return f_password;
                case (5): return f_sender;
                case (6): return f_address;
                case (7): return f_reserved;
                case (8): return f_phone;
                case (9): return f_caps;
                case (10): return f_receiver;
                case (11): return f_comments;
                case (12): return f_processing_id;
                case (13): return f_version;
                case (14): return f_timestamp;
                default: return null;
            }
        }

        public override bool addComment(String recordData)
        {
            commentRecords.Add(new ASTM_Comment());
            return commentRecords.Last().parseData(recordData);
        }

        public override bool addManufacturerInfo(String recordData)
        {
            manufacturerRecords.Add(new ASTM_Manufacturer());
            return manufacturerRecords.Last().parseData(recordData);
        }

        public override bool parseData(String recordData)
        {
            var recordValues = Regex.Split(recordData, "[|]");
            int idx = 1;
            foreach (var v in recordValues)
            {
                switch (idx)
                {
                    case (1): f_type = v; break;
                    case (2): f_delimeter = v; break;
                    case (3): f_message_id = v; break;
                    case (4): f_password = v; break;
                    case (5): f_sender = v; break;
                    case (6): f_address = v; break;
                    case (7): f_reserved = v; break;
                    case (8): f_phone = v; break;
                    case (9): f_caps = v; break;
                    case (10): f_receiver = v; break;
                    case (11): f_comments = v; break;
                    case (12): f_processing_id = v; break;
                    case (13): f_version = v; break;
                    case (14): f_timestamp = v; break;
                    default: return false;
                }
                idx++;
            }
            return true;
        }
    }

    public class Parser
    {
        public Parser()
        {
            
        }

        public void parse(String astmData, ref List<ASTM_Message>  messages)
        {            
            var lines = Regex.Split(astmData, "\r\n|\r|\n");
            ASTM_Message m = null;
            ASTM_Record curRec = null;
            foreach (var l in lines)
            { 
                var entries = Regex.Split(l, "[|]");
                switch (entries.ElementAt(0))
                { 
                    case "H":
                        messages.Add(new ASTM_Message());
                        m = messages.Last();
                        curRec = m;
                        curRec.parseData(l);
                        break;
                    case "P":
                        if (m != null)
                        {
                            m.patientRecords.Add(new ASTM_Patient());
                            curRec = m.patientRecords.Last();
                            curRec.parseData(l);
                        }
                        else
                        { 
                            //TODO Error
                        }
                        break;
                    case "O":
                        if (m != null)
                        {
                            if (m.patientRecords.Count > 0 && m.patientRecords.Last() != null)
                            {
                                m.patientRecords.Last().orderRecords.Add(new ASTM_Order());
                                curRec = m.patientRecords.Last().orderRecords.Last();
                                curRec.parseData(l);
                            }
                            else
                            {
                                //TODO Error: no patient
                            }
                        }
                        else
                        {
                            //TODO Error
                        }
                        break;
                    case "R":
                        if (m != null)
                        {
                            if (m.patientRecords.Count > 0 && m.patientRecords.Last() != null)
                            {
                                if (m.patientRecords.Last().orderRecords.Count > 0 && m.patientRecords.Last().orderRecords.Last() != null)
                                {
                                    m.patientRecords.Last().orderRecords.Last().resultRecords.Add( new ASTM_Result() );
                                    curRec = m.patientRecords.Last().orderRecords.Last().resultRecords.Last();
                                    curRec.parseData(l);
                                }                               
                            }
                            else
                            {
                                //TODO Error: no patient
                            }
                        }
                        else
                        {
                            //TODO Error
                        }
                        break;
                    case "Q":
                        if (m != null)
                        {
                            m.requestRecords.Add(new ASTM_Request());
                            curRec = m.requestRecords.Last();
                            curRec.parseData(l);
                        }
                        else
                        {
                            //TODO Error
                        }
                        break;
                    case "C":
                        if (curRec != null)
                        {
                            curRec.addComment(l);
                        }
                        else
                        {
                            //TODO Error
                        }
                        break;
                    case "M":
                        if (curRec != null)
                        {
                            curRec.addManufacturerInfo(l);
                        }
                        else
                        {
                            //TODO Error
                        }
                        break;
                    case "L":
                        if (m != null)
                        {
                            curRec=null;
                            m = null;
                        }
                        else
                        {
                            //TODO Error
                        }
                        break;

                    default:
                        //TODO Warning unknown record, store in message
                        break;
                }

            }
        }
    }
}
