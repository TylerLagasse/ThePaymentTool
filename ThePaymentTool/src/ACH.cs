using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACH_Decomp
{
    class ACH
    {
    }
    class FHR
    {
        public string RecordTypeCode;
        public string PriorityCode;
        public string ImmediateDestination;
        public string ImmediateOrigin;
        public string FileCreationDate;
        public string FileCreationTime;
        public string FileIDModifier;
        public string RecordSize;
        public string BlockingFactor;
        public string FormatCode;
        public string ImmediateDestinationName;
        public string ImmediateOriginName;
        public string ReferenceCode;
    }
    class BHR
    {
        public string RecordTypeCode;
        public string ServiceClassCode;
        public string CompanyName;
        public string CompanyDiscretionaryData;
        public string CompanyIdentification;
        public string StandardEntryClassCode;
        public string CompanyEntryDescription;
        public string CompanyDescriptiveDate;
        public string EffectiveEntryDate;
        public string SettlementDate;
        public string OriginatorStatusCode;
        public string OriginatingDFIIdentification;
        public string BatchNumber;
        /* IAT Exclusive */
        public string IATIndicator;
        public string ForeignExchangeIndicator;
        public string ForeignExchangeReferenceIndicator;
        public string ForeignExchangeReference;
        public string ISODestinationCode;
        public string OriginiatorIdentification;
        public string ISOOriginatingCurrencyCode;
        public string ISODestinationCurrencyCode;
    }
    class PPD
    {
        public string RecordTypeCode;
        public string TransactionCode;
        public string ReceivingDFIIdentification;
        public string CheckDigit;
        public string DFIAccountNumber;
        public string Amount;
        public string IndividualIdentificationNumber;
        public string IndividualName;
        public string DiscretionaryData;
        public string AddendaRecordIndicator;
        public string TraceNumber;
    }
    class CCD
    {
        public string RecordTypeCode;
        public string TransactionCode;
        public string ReceivingDFIIdentification;
        public string CheckDigit;
        public string DFIAccountNumber;
        public string Amount;
        public string IdentificationNumber;
        public string ReceivingCompanyName;
        public string DiscretionaryData;
        public string AddendaRecordIndicator;
        public string TraceNumber;
    }
    class TEL
    {
        public string RecordTypeCode;
        public string TransactionCode;
        public string ReceivingDFIIdentification;
        public string CheckDigit;
        public string DFIAccountNumber;
        public string Amount;
        public string IndividualIdentificationNumber;
        public string IndividualName;
        public string DiscretionaryData;
        public string AddendaRecordIndicator;
        public string TraceNumber;
    }
    class WEB
    {
        public string RecordTypeCode;
        public string TransactionCode;
        public string ReceivingDFIIdentification;
        public string CheckDigit;
        public string DFIAccountNumber;
        public string Amount;
        public string IndividualIdentificationNumber;
        public string IndividualName;
        public string PaymentTypeCode;
        public string AddendaRecordIndicator;
        public string TraceNumber;
    }
    class CTX
    {
        public string RecordTypeCode;
        public string TransactionCode;
        public string ReceivingDFIIdentification;
        public string CheckDigit;
        public string DFIAccountNumber;
        public string TotalAmount;
        public string IdentificationNumber;
        public string NumberOfAddendaRecords;
        public string ReceivingCompanyName;
        public string Reserved;
        public string DiscretionaryData;
        public string AddendaRecordIndicator;
        public string TraceNumber;
    }
    class IAT
    {
        public string RecordTypeCode;
        public string TransactionCode;
        public string ReceivingDFIIdentification;
        public string CheckDigit;
        public string NumberOfAddendaRecords;
        public string Reserved;
        public string Amount;
        public string ForeignReceiverAcct;
        public string Reserved2;
        public string GatewayOperator;
        public string SecondaryOFAC;
        public string AddendaRecordIndicator;
        public string TraceNumber;
    }
    class Addenda
    {
        public string RecordTypeCode;
        public string AddendaTypeCode;
        public string PaymentRelatedInformation;
        public string AddendaSequenceNumber;
        public string EntryDetailSequenceNumber;
        /*IAT Exclusive*/
        public string TransactionTypeCode;
        public string ForeignPaymentAmount;
        public string ForeignTraceNumber;
        public string ReceivingCompanyName;
        public string OriginatorName;
        public string OriginatorStreetAddress;
        public string Reserved;
        public string OriginatorCityStateProvince;
        public string OriginatorCountryPostalCode;
        public string OriginatingDFIName;
        public string OriginatingDFIIDNumber;
        public string OriginatingDFIIdentification;
        public string OriginatingDFIBranch;
        public string ReceivingDFIName;
        public string ReceivingDFIIDNumber;
        public string ReceivingDFIIdentification;
        public string ReceivingDFIBranch;
        public string ReceiverIDNumber;
        public string ReceiverStreetAddress;
        public string ReceiverCityStateProvince;
        public string ReceiverCountryPostalCode;
    }
    class BCR
    {
        public string RecordTypeCode;
        public string ServiceClassCode;
        public string EntryAddendaCount;
        public string EntryHash;
        public string TotalDebitEntryAmount;
        public string TotalCreditEntryAmount;
        public string CompanyIdentification;
        public string MessageAuthenticationCode;
        public string Reserved;
        public string OriginatingDFIIdentification;
        public string BatchNumber;
    }
    class FCR
    {
        public string RecordTypeCode;
        public string BatchCount;
        public string BlockCount;
        public string EntryAddendaCount;
        public string EntryHash;
        public string TotalDebitEntryAmount;
        public string TotalCreditEntryAmount;
        public string Reserved;
    }
}
