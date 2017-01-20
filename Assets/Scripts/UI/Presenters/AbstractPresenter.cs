using UnityEngine;


namespace iLogos.TankSurvival
{
    public abstract class AbstractPresenter : MonoBehaviour
    {
        [SerializeField]
        private Transform _presentersRoot;

        protected AbstractPresenter CreatePresenterInstance(GameObject prototype)
        {
            GameObject instance = Instantiate<GameObject>(prototype, Vector3.zero, Quaternion.identity);

            instance.transform.SetParent(_presentersRoot, false);
            instance.gameObject.SetActive(true);

            return instance.GetComponent<AbstractPresenter>();
        }

        protected void ClearPresentersRoot()
        {
            foreach(Transform child in _presentersRoot.transform)
                Destroy(child.gameObject);
        }
    }
}