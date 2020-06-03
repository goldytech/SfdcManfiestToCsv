using System.Threading.Tasks;
using BlazorFileSaver;
using ClientApp.Domain.SfdcManifestConverter;
using Microsoft.AspNetCore.Components;
using W8lessLabs.Blazor.LocalFiles;

namespace ClientApp.Pages
{
    public class IndexBase : ComponentBase
    {
        // Component reference
       public FileSelect BlazorFileSelect;

       public string Message { get; set; } = string.Empty;

       public string CssClass { get; set; } = string.Empty;

       [Inject]
       public IConverter Converter { get; set; }

       [Inject]
       private IBlazorFileSaver BlazorFileSaver { get; set; }
        // Handle the file selection event
        public async Task FilesSelectedHandler(SelectedFile[] selectedFiles)
        {
            // example of opening a selected file...
            var selectedFile = selectedFiles[0];
            // load all the bytes at once
            
            var fileBytes = await BlazorFileSelect.GetFileBytesAsync(selectedFile.Name);
            var package = Converter.Convert(fileBytes);
            if (package != null)
            {
                Message = "File Converted Successfully";
                CssClass = "alert alert-success";
                StateHasChanged();
                var csvData = Converter.BuildCsvFile(package.Types);
                await BlazorFileSaver.SaveAs("packagexml.csv", csvData);
            }
            else
            {
                Message = "Error encountered. Please check the file format";
                CssClass = "alert alert-danger";
                StateHasChanged();
            }

        }

       public void SelectFile()
       {
           BlazorFileSelect.SelectFiles();
       }
    }
}