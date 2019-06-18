using System.Collections.ObjectModel;
using System.Linq;

using Vernizze.Infra.CrossCutting.Extensions;

namespace Vernizze.Infra.CrossCutting.Utils
{
    public class RoundRobin
    {
        private ObservableCollection<RoundRobinDetail> _itens;
        private RoundRobinDetail _current = null;

        public RoundRobin()
        {
            this._itens = new ObservableCollection<RoundRobinDetail>();
        }

        public RoundRobinDetail Current
        {
            get { return this._current; }
        }

        private void ReOrder()
        {
            var index = 1;

            if (this._itens.HaveAny())
            {
                var current_index = this._current?.Index ?? 0;

                this._itens.OrderBy(o => o.Index).ToList().ForEach(i =>
                {
                    i.Index = index;

                    index++;
                });

                if (current_index > this._itens.Count - 1)
                    this._current = this._itens[this._itens.Count - 1];
                else
                    this._current = this._itens[current_index];
            }
        }

        public bool HaveAny()
        {
            return this._itens.HaveAny();
        }

        public void Add(string key)
        {
            var exists = this._itens.Where(i => i.Key.Equals(key)).HaveAny();

            if (!exists)
                this._itens.Add(new RoundRobinDetail
                {
                    Index = this._itens.Count() + 1,
                    Key = key
                });

            if (this._itens.Count.Equals(1))
                this._current = this._itens.First();
        }

        public void Remove(string key)
        {
            var exists = this._itens.Where(i => i.Key.Equals(key)).HaveAny();

            if (exists)
            {
                var remove_item = this._itens.Where(i => i.Key.Equals(key)).First();

                if (remove_item.Index < this._current.Index)
                    this.Previous();

                this._itens.Remove(remove_item);

                this.ReOrder();
            }
        }

        public void First()
        {
            if (this._itens.HaveAny())
            {
                var index = 1;

                var new_current = this._itens.Where(i => i.Index.Equals(index));

                if (new_current.HaveAny())
                    this._current = new_current.First();
            }
            else
            {
                this._current = null;
            }
        }

        public void Next()
        {
            if (this._itens.HaveAny())
            {
                var index = 0;

                if (this._current.Index.Equals(1))
                    index = this._itens.Min(i => i.Index);

                var new_current = this._itens.Where(i => i.Index.Equals(index + 1));

                if (new_current.HaveAny())
                    this._current = new_current.First();
            }
            else
            {
                this._current = null;
            }
        }

        public void Previous()
        {
            if (this._itens.HaveAny())
            {
                var index = 0;

                if (this._current.Index.Equals(1))
                    index = this._itens.Max(i => i.Index);

                var new_current = this._itens.Where(i => i.Index.Equals(index - 1));

                if (new_current.HaveAny())
                    this._current = new_current.First();
            }
            else
            {
                this._current = null;
            }
        }

        public void Last()
        {
            if (this._itens.HaveAny())
            {
                var index = 0;

                if (this._current.Index.Equals(1))
                    index = this._itens.Max(i => i.Index);

                var new_current = this._itens.Where(i => i.Index.Equals(index));

                if (new_current.HaveAny())
                    this._current = new_current.First();
            }
            else
            {
                this._current = null;
            }
        }
    }

    public class RoundRobinDetail
    {
        public int Index { get; set; }
        public string Key { get; set; }
    }
}
