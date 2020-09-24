function checkPalindrome(inputString) {
  let inputToString = inputString.split("");

  return inputToString.reverse().join("") === inputString;
}
// console.log(checkPalindrome("aabaa"));

function returnAPromise(param1, param2) {
  return new Promise((resolve, reject) => {
    if (param1 == param2) {
      resolve(true);
    }
    reject(false);
  });
}

async function returnPromiseAwait(param1, param2) {
  return param1 == param2;
}

returnAPromise(1, 2)
  .then((result) => {
    console.log(result);
  })
  .catch((error) => console.log(error));

returnPromiseAwait(1, 2)
  .then((result) => {
    console.log(result);
  })
  .catch((error) => console.log(error));
