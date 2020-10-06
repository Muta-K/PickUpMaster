<?php
namespace App\Test\TestCase\Model\Table;

use App\Model\Table\PickupmasterTable;
use Cake\ORM\TableRegistry;
use Cake\TestSuite\TestCase;

/**
 * App\Model\Table\PickupmasterTable Test Case
 */
class PickupmasterTableTest extends TestCase
{

    /**
     * Test subject
     *
     * @var \App\Model\Table\PickupmasterTable
     */
    public $Pickupmaster;

    /**
     * Fixtures
     *
     * @var array
     */
    public $fixtures = [
        'app.pickupmaster'
    ];

    /**
     * setUp method
     *
     * @return void
     */
    public function setUp()
    {
        parent::setUp();
        $config = TableRegistry::getTableLocator()->exists('Pickupmaster') ? [] : ['className' => PickupmasterTable::class];
        $this->Pickupmaster = TableRegistry::getTableLocator()->get('Pickupmaster', $config);
    }

    /**
     * tearDown method
     *
     * @return void
     */
    public function tearDown()
    {
        unset($this->Pickupmaster);

        parent::tearDown();
    }

    /**
     * Test initialize method
     *
     * @return void
     */
    public function testInitialize()
    {
        $this->markTestIncomplete('Not implemented yet.');
    }

    /**
     * Test validationDefault method
     *
     * @return void
     */
    public function testValidationDefault()
    {
        $this->markTestIncomplete('Not implemented yet.');
    }
}
