using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace Sprint.SESAT.IDMSample.Client.iOS
{
    class SampleDataTableViewSource:UITableViewSource
    {
        private readonly List<string> _listItems; 

        public SampleDataTableViewSource(IEnumerable<string> listItems)
        {
            _listItems = listItems.ToList();
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell((NSString) "defaultCell") ??
                       new UITableViewCell(UITableViewCellStyle.Default, (NSString)"defaultCell");

            cell.TextLabel.Text = _listItems[indexPath.Row];
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _listItems.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, false);
        }
    }
}
