using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    public class NodeUIPool : MonoBehaviour
    {
        [SerializeField] private NodeUI prefab;

        private List<NodeUI> _pool = new List<NodeUI>();
        
        public static NodeUIPool Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public NodeUI Get()
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

        public void Return(NodeUI ui)
        {
            ui.gameObject.SetActive(false);
        }
    }
}