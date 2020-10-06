<?php
namespace App\Controller;

use App\Controller\AppController;

/**
 * Pickupmaster Controller
 *
 * @property \App\Model\Table\PickupmasterTable $Pickupmaster
 *
 * @method \App\Model\Entity\Pickupmaster[]|\Cake\Datasource\ResultSetInterface paginate($object = null, array $settings = [])
 */
class PickupmasterController extends AppController
{
    public function getItemlist()
    {
        error_log("getItemlist()");
        $this->autoRender = false;
        
        
        $this->loadModel('pumitem');

        //$id = $this->request->query('id');

        $itemquery = $this->pumitem->find('all');

        $array = json_encode($itemquery);

        echo $array;
        //echo id;

        

    }


}
