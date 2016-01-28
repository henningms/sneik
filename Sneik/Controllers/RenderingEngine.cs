using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sneik.Views.Interfaces;

namespace Sneik.Controllers
{
    /// <summary>
    /// Rendering Engine
    /// 
    /// Responsible for adding, deleting and rendering game views.
    /// Easily extendable for future uses
    /// </summary>
    public class RenderingEngine
    {
        /// <summary>
        /// List of all game views
        /// </summary>
        public IList<IGameView> Views { get; set; } 

        /// <summary>
        ///  Initializes the rendering engine
        /// </summary>
        public RenderingEngine()
        {
            Views = new List<IGameView>();
        }

        /// <summary>
        /// Adds a new game view
        /// </summary>
        /// <param name="view">View to add</param>
        public void AddView(IGameView view)
        {
            Views.Add(view);
        }

        /// <summary>
        /// Removes a game view from the engine's list
        /// </summary>
        /// <param name="view">View to delete</param>
        /// <returns></returns>
        public bool RemoveView(IGameView view)
        {
            return Views.Remove(view);
        }

        /// <summary>
        /// Removes a game view from the list based on index
        /// </summary>
        /// <param name="index">Index of the view</param>
        public void RemoveViewAt(int index)
        {
            Views.RemoveAt(index);
        }

        /// <summary>
        /// Renders all views from bottom to top
        /// </summary>
        public void Draw()
        {
            foreach (var view in Views)
            {
                view.Draw();
            }
        }
    }   
}
