using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace Sprint.SESAT.IDMSample.Client.Droid.Utils
{
    public class SampleAdapter : BaseAdapter<string>
    {
        private readonly Context _context;
        private readonly List<string> _items;

        public override int Count => _items.Count;

        public override string this[int position] => _items[position];

        public SampleAdapter(IEnumerable<string> items, Context context)
        {
            _context = context;
            _items = items.ToList();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
        {
            var view = convertView ?? LayoutInflater.FromContext(_context).Inflate(Resource.Layout.SampleItem, null);
            var sampleText = view.FindViewById<TextView>(Resource.Id.sampleTextView);
            sampleText.Text = _items[position];

            return view;
        }
    }
}