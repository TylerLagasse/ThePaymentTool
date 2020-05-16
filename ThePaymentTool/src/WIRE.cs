using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACH_Decomp
{
    class FileHeader
    {
        public string RecordCode;
        public string ABAFRB;
        public string ReceiverIdentification;
        public string FileCreationDate;
        public string FileCreationTime;
        public string FileIDNumber;
        public string PhysicalRecordLength;
        public string BlockSize;
        public string VersionNumber;
    }
    class GroupHeader
    {
        public string RecordCode;
        public string ReceiverIdentification;
        public string ABAFRB;
        public string GroupStatus;
        public string AsOfDate;
        public string AsOfTime;
        public string CurrencyCode;
        public string AsOfDateModififer;
    }
    class AccountIdentifier
    {
        public string RecordCode;
        public string CustomerAccountNumber;
        public string CurrencyCode;
        public string TypeCode;
        public string Amount;
        public string ItemCount;
        public string FundsType;
    }
    class TransactionDetail
    {
        public string RecordCode;
        public string TypeCode;
        public string Amount;
        public string FundsType;
        public string StateSite;
        public string Text;
        public string SField1;
        public string SField2;
        public string SField3;
        public string VField1;
        public string VField2;
        public string D1;
        public string D2;
        public string D3;
        public string D4;
        public string D5;
        public string D6;
    }
    class DType
    {
        public string dayAvail;
        public string amtAvail;
    }
    class ContinuationRecord
    {
        public string RecordCode;
        public string NextField;
    }
    class AccountTrailer
    {
        public string RecordCode;
        public string AccountControlTotal;
        public string NumberOfRecords;
    }
    class GroupTrailer
    {
        public string RecordCode;
        public string GroupControlTotal;
        public string NumberOfAccounts;
        public string NumberOfRecords;
    }
    class FileTrailer
    {
        public string RecordCode;
        public string FileControlTotal;
        public string NumberOfGroups;
        public string NumberOfRecords;
    }
}
