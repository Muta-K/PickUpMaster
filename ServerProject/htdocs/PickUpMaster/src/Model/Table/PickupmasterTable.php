<?php
namespace App\Model\Table;

use Cake\ORM\Query;
use Cake\ORM\RulesChecker;
use Cake\ORM\Table;
use Cake\Validation\Validator;

/**
 * Pickupmaster Model
 *
 * @method \App\Model\Entity\Pickupmaster get($primaryKey, $options = [])
 * @method \App\Model\Entity\Pickupmaster newEntity($data = null, array $options = [])
 * @method \App\Model\Entity\Pickupmaster[] newEntities(array $data, array $options = [])
 * @method \App\Model\Entity\Pickupmaster|bool save(\Cake\Datasource\EntityInterface $entity, $options = [])
 * @method \App\Model\Entity\Pickupmaster|bool saveOrFail(\Cake\Datasource\EntityInterface $entity, $options = [])
 * @method \App\Model\Entity\Pickupmaster patchEntity(\Cake\Datasource\EntityInterface $entity, array $data, array $options = [])
 * @method \App\Model\Entity\Pickupmaster[] patchEntities($entities, array $data, array $options = [])
 * @method \App\Model\Entity\Pickupmaster findOrCreate($search, callable $callback = null, $options = [])
 */
class PickupmasterTable extends Table
{

    /**
     * Initialize method
     *
     * @param array $config The configuration for the Table.
     * @return void
     */
    public function initialize(array $config)
    {
        parent::initialize($config);

        $this->setTable('pickupmaster');
        $this->setDisplayField('Id');
        $this->setPrimaryKey('Id');
    }

    /**
     * Default validation rules.
     *
     * @param \Cake\Validation\Validator $validator Validator instance.
     * @return \Cake\Validation\Validator
     */
    public function validationDefault(Validator $validator)
    {
        $validator
            ->integer('Id')
            ->allowEmpty('Id', 'create');

        return $validator;
    }
}
