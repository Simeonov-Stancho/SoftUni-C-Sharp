function loadRepos() {
	let username = document.getElementById('username');
	const url = `https://api.github.com/users/${username.value}/repos`;
	let ulEl = document.getElementById('repos');

	fetch(url)
		.then(response => {
			if (response.ok == false) {
				throw new Error(`${response.status} ${response.statusText}`)
			}
			return response.json()
		})
		.then(handleResponse)
		.catch(handleError);

	function handleResponse(data) {
		ulEl.innerHTML = '';

		for (let repo of data) {
			let liEl = document.createElement('li');
			liEl.innerHTML = `<a href="${repo.html_url}">${repo.full_name}</a>`;
			ulEl.appendChild(liEl);
		}

		username.value = '';
	}

	function handleError(error) {
		ulEl.innerHTML = '';
		ulEl.textContent = error.message;
	}

}