using System.Threading.Tasks;
using UnityEngine;

namespace ObjectToggler.Transitions
{
    public abstract class AbstractTogglerTransition : ScriptableObject
    {
        /// <summary>
        /// Подготовка перед анимацией, from включен, to еще нет
        /// </summary>
        public abstract void BeforeTransition(Transform from, Transform to);

        /// <summary>
        /// Сама анимация, все включено
        /// </summary>
        public abstract Task Transition(Transform from, Transform to);

        /// <summary>
        /// Состояние после анимации, все включено, выключится from автоматически
        /// </summary>
        public abstract void AfterTransition(Transform from, Transform to);
    }
}