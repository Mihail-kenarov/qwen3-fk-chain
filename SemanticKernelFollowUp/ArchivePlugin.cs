using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticKernelFollowUp
{
    public class ArchivePlugin
    {
        [KernelFunction("archive_data")]
        [Description("Save data to a file on your computer.")]
        [return: Description("A list of archived news items")]
        public async Task WriteData(Kernel kernel, string filename, string data)
        {
            await File.WriteAllTextAsync(
                $@"{filename}.txt",data);
        }

    }
}
