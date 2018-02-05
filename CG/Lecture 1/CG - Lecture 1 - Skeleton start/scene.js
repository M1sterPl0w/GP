// Create scene
var scene = new THREE.Scene();

// Create camera
var camera = new THREE.PerspectiveCamera(
	75, // fov — Camera frustum vertical field of view.
	window.innerWidth/window.innerHeight, // aspect — Camera frustum aspect ratio.
	0.1, // near — Camera frustum near plane.
	1000); // far — Camera frustum far plane. 

// Create renderer
var renderer = new THREE.WebGLRenderer({ antialias: true, alpha: true });
renderer.setSize(window.innerWidth, window.innerHeight);
document.body.appendChild(renderer.domElement);

var geometry  = new THREE.BoxGeometry(1, 1, 1);
var material = new THREE.MeshNormalMaterial();
var cube = new THREE.Mesh(geometry, material);
scene.add(cube);

camera.position.x = 2;
camera.position.y = 1;
camera.position.z = 5;

// light voor normal mapping
var ambient = new THREE.AmbientLight(0x404040);
scene.add(ambient);
var light = new THREE.DirectionalLight

//var controls = new THREE.OrbitControls(camera);
//controls.autoRotate = true;
//controls.autoRotateSpeed = 2;
//controls.noKeys = false;

//renderer.render(scene, camera);
var clock = new THREE.Clock();
 
var render = function(){
	requestAnimationFrame(render);
	var delta = clock.getDelta();
	//controls.update();
	cube.rotation.x += 3.2 * delta;
	cube.rotation.y += 3.2 * delta;
	cube.rotation.z += delta;
	renderer.render(scene, camera);
};

render();