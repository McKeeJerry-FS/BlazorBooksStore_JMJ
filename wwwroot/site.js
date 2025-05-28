function showAlert(name) {
  alert('Hello ' + name);
}

async function callStaticCSharpMethod() {
  await DotNet.InvokeMethodAsync('BlazorBooksStore', 'Sum', 5, 10)
  .then(data => {
    console.log('Result from C# method:', data);
  })
  .catch(error => {
    console.error('Error calling C# method:', error);
  });
}

function triggerOnWindowResized(dotnetObjRef) {
  window.onresize = function () {
    dotnetObjRef.invokeMethodAsync('OnWindowResized', window.innerWidth, window.innerHeight);
  }
}