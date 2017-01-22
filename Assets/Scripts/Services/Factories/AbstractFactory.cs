using UnityEngine;


namespace iLogos.TankSurvival
{
    public abstract class AbstractFactory : MonoBehaviour
    {
        protected T CreateInstance<T>(GameObject prototype)
        {
            GameObject instance = Pool.Instance.Get(prototype);

            instance.transform.SetParent(this.transform);
            instance.SetActive(true);

            return instance.GetComponent<T>();
        }

        public void DestroyInstances()
        {
            foreach(Transform child in this.transform)
                child.GetComponent<AbstractEntity>().DestroyInstance();
        }
    }
}