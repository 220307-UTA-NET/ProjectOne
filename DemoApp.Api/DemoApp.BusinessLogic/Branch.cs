namespace DemoApp.BusinessLogic
{
    public class Branch
    {

        public string? branchCode { get; set; }
        public string? branchName { get; set; }
        public string? branchAddress { get; set; }


        Branch() { }

        public Branch(string branchCode, string branchName, string branchAddress)
        {
            this.branchCode = branchCode;
            this.branchName = branchName;
            this.branchAddress = branchAddress;
        }

        public string getBranchCode()
        {
            return this.branchCode;
        }

        public string setBranchCode(string branchCode)
        {
            return this.branchCode = branchCode;
        }

        public string getBranchName()
        {
            return this.branchName;
        }

        public string setBranchName(string branchName)
        {
            return this.branchName = branchName;
        }

        public string getBranchAddress()
        {
            return this.branchName;
        }

        public string setBranchAddress(string branchAddress)
        {
            return this.branchName = branchAddress;
        }
        

    }
}