using UnityEngine;


namespace iLogos.TankSurvival
{
    public abstract class AbstractFactory : MonoBehaviour
    {
        protected T CreateInstance<T>(GameObject prototype)
        {
            GameObject instance = Instantiate(prototype, Vector3.zero, Quaternion.identity);

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