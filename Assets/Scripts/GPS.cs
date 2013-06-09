using UnityEngine;


class GPS{
	// Remember: +X axis is 0 longitude!
	
	
	private static int surface_ray_height = 1000; //ray height to get dist and normal to ground
	private static LayerMask ground = 1 << 8;
	
	//get longitude from a point.
	public static float getLatitude(Vector3 position) {
		return Mathf.Rad2Deg * Mathf.Asin(position.y/position.magnitude);
	}
	
	//get latitude from a point.
	public static float getLongitude(Vector3 position) {
		//	longitude must consider x and z.
		return Mathf.Rad2Deg * Mathf.Atan2(position.x, position.z);
	}
	
	//get (latitude, longitude) from a point.
	public static Vector2 getGPS(Vector3 position){
		return new Vector2(	getLatitude(position), getLongitude(position));
	}
	
	//get a normalized vector with the given latitude and longitude.
	public static Vector3 getNormalizedPosition(Vector2 latLong){
		return new Vector3(	Mathf.Cos(latLong[1]), Mathf.Sin(latLong[0]), Mathf.Sin(latLong[1]));
	}
	
	// get the raycastHit on the surface at this longitude/latitude.
	//	raycastHit has raycastHit.point, raycastHit.Normal and more!
	public static RaycastHit getRaycastHit(Vector2 latLong){
		RaycastHit ray;
		Vector3 normalizedPosition = getNormalizedPosition(latLong);
		Physics.Raycast(normalizedPosition * surface_ray_height, -normalizedPosition, out ray, surface_ray_height, ground);
		return ray;
	}
	// get the raycastHit on the surface at this position's long/lat.
	//	raycastHit has raycastHit.point, raycastHit.Normal and more!
	public static RaycastHit getRaycastHit(Vector3 position){
		RaycastHit ray;
		Physics.Raycast(position.normalized * surface_ray_height, -position, out ray, surface_ray_height, ground);
		return ray;
	}
	
	// gets position on surface from latLong.
	// Uses a raycast, consider getNormalizedPos if you don't need on surface or
	// getRaycastHit if you need on surface and the normal.
	public static Vector3 getPosition(Vector2 latLong){
		RaycastHit ray = getRaycastHit(latLong);
		return ray.point;
	}
	
	// Get a vector to head in to get from myPos to targetPos.
	// The vector is tangent to the surface at myLatLong and length step.
	// Note that Math here assumes the world is a sphere.
	public static Vector3 getHeading( Vector3 myPos, Vector3 targetPos){
		
		// Find the plane that goes through myLatLong, targetLatLong, and the origin
		//	it's normal is orthogonal to the two points, so it's their cross product:
		Vector3 normalToPlane = Vector3.Cross(myPos, targetPos);
		
		// the plane is orthogonal to that normal, and we want a vector orthogonal to the
		// planet normal, so take the cross product of those two and we'll be left with 
		// just two choices:
		RaycastHit surfaceRay = getRaycastHit(myPos);
		Vector3 heading = Vector3.Cross(normalToPlane, surfaceRay.normal);
		heading.Normalize();
		
		// if targetPos is behind heading, go in -heading:
		if( Vector3.Dot(heading, targetPos) < 0){
			return -1 * heading;
		} else {
			return heading;
		}
	}
	
	// returns a raycastHit from the given point on the screen.
	public static RaycastHit getRaycastHitFromScreenPos(Vector3 screenPos){
		RaycastHit hit;
		Physics.Raycast(Camera.main.ViewportPointToRay(screenPos), out hit);
		return hit;
	}
	
	// returns a random position on the planet's surface.
	public static Vector3 getRandomPosition(){
		return getRaycastHit(Random.onUnitSphere).point;
	}
}