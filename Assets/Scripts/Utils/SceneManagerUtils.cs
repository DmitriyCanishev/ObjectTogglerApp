using System.Threading.Tasks;
using UnityEngine;

namespace Utils
{
    public static class SceneManagerUtils
    {
        public static Task ToTask(this AsyncOperation asyncOperation)
        {
            var completionSource = new TaskCompletionSource<object>();
            
            void OnCompleted(AsyncOperation asyncOperation)
            {
                asyncOperation.completed -= OnCompleted;
                completionSource.SetResult(null);
            }
            asyncOperation.completed += OnCompleted;

            return completionSource.Task;
        }
    }
}