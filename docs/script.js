function getLatestRelease() {
	const svg1 = document.querySelector('[role="img"]');
    const shape = svg1.querySelector('[x="553"]');
    const text = shape.innerHTML;
    //svg1.insertAdjacentHTML('beforebegin', text);
    return text;
}

function getReleases() {
    const svg1 = document.querySelector('[role="img"]');
    const shape = svg1.querySelector('[x="610"]');
    const text = shape.innerHTML;
    //svg1.insertAdjacentHTML('beforebegin', text);
    return text;
}

document.getElementById("release").innerHTML = getLatestRelease();
document.getElementById("releases").innerHTML = getReleases();