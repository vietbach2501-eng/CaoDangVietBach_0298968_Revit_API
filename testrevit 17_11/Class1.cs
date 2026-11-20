using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
namespace testrevit_17_11
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Class1:IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();
            Autodesk.Revit.UI.TaskDialog.Show("Revit", "Số lượng đối tượng được chọn: " + selectedIds.Count.ToString());
            ICollection<ElementId> selectedWallIds = new List<ElementId>();
            foreach (ElementId id in selectedIds)
            {
                Element elements1 = uidoc.Document.GetElement(id);
                if (elements1 is Wall)
                {
                    selectedWallIds.Add(id);
                }
            }
            // Set the created element set as current select element set.
            uidoc.Selection.SetElementIds(selectedWallIds);
            if (0 != selectedWallIds.Count)
            {
                Autodesk.Revit.UI.TaskDialog.Show("Revit", selectedWallIds.Count.ToString() + " Đối tượng Tường đã được chọn!");
            }
            else
            {
                Autodesk.Revit.UI.TaskDialog.Show("Revit", "Không có đối tượng tường nào được chọn!");
            }
            return Result.Succeeded;
        }
    }
}
