using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace Pools
{
    public class Pool<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T prefab;
        private List<T> _pool = new List<T>();
        
        public static Pool<T> Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public T Get()
        {
            var ui = _pool.FirstOrDefault(x => !x.gameObject.activeInHierarchy);
            if (ui is null)
            {
                ui = Instantiate(prefab, transform);
                _pool.Add(ui);
            }
            ui.gameObject.SetActive(true);
            return ui;
        }
        
        public void Return(T ui)
        {
            ui.gameObject.SetActive(false);
        }
    }
    
    public class NodeUIPool : Pool<NodeUI> { }
    public class NodeVisualPool : Pool<NodeVisual> { }
    public class UnitVisualPool : Pool<UnitVisual> {}
}