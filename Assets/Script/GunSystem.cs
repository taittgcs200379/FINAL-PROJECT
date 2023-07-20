
using UnityEngine;
using TMPro;
using System.Collections;

public class GunSystem : MonoBehaviour
{
    public GameObject Bullet;
    public float shootforce, upwardforce;
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    public int maxAmmo;
    int currentmaxAmmo;

    //Recoil
    public Rigidbody playerRb;
    public float recoilForce;
    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera PlayerCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;
    
    
    public TextMeshProUGUI text;

    public bool allowInvoke = true;
    private void Awake()
    {
         bulletsLeft = magazineSize;
        currentmaxAmmo = maxAmmo;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        //SetText
        if(text !=null)
        text.SetText(bulletsLeft+ " / " + currentmaxAmmo);
    }
    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft<magazineSize && !reloading) Reload();
        
        
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();
        
        
        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;

        Ray ray = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Just a ray through the middle of your current view
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;
        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        
        //Calculate Direction with Spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(Bullet, attackPoint.position, Quaternion.identity);

        currentBullet.transform.forward = directionWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootforce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(PlayerCam.transform.up * upwardforce, ForceMode.Impulse);

        
        //Graphics
        
        if(Bullet.GetComponent<Rigidbody>() != null) 
        Instantiate(bulletHoleGraphic, hit.point, Quaternion.Euler(0, 180, 0));
        

        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        bulletsLeft--;
        bulletsShot++;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;

            //Add recoil to player (should only be called once)
            playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
        }

        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
        // RayCast
        if (Physics.Raycast(ray, out hit, range, whatIsEnemy))
        {
            

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal);
            }

            EnemyAi e = hit.transform.GetComponent<EnemyAi>();
            if (e != null) 
            {
                e.GetDamage(damage);
                return;
            }
        }
    }
    
    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }
    private void Reload()
    {
        
        if ((magazineSize - bulletsLeft) <= currentmaxAmmo)
        {
            currentmaxAmmo -= (magazineSize - bulletsLeft);
            bulletsLeft += (magazineSize - bulletsLeft);
            Invoke("ReloadFinished", reloadTime);
            reloading = true;
           
        }
        else
        {
            bulletsLeft += currentmaxAmmo;
            currentmaxAmmo = 0;
            reloading= false;
        }
        
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
